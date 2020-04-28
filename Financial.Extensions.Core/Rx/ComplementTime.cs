﻿//==============================================================================
// Copyright (c) 2012-2020 Fiats Inc. All rights reserved.
// https://www.fiats.asia/
//

using System;
using System.Reactive.Linq;

namespace Financial.Extensions
{
    public static partial class RxExtensions
    {
        // Complement element between periods if whici is not supplied.
        public static IObservable<TSource> ComplementPeriods<TSource>(
            this IObservable<TSource> source,
            Func<TSource, DateTime> getTime,
            Func<DateTime, TSource, TSource> createComplement,
            TimeSpan timeInterval
        )
        {
            return Observable.Create<TSource>(observer =>
            {
                source.Buffer(2, 1).Subscribe(e =>
                {
                    if (e.Count < 2)
                    {
                        observer.OnNext(e[0]);
                        return;
                    }

                    var fromTime = getTime(e[0]);
                    var toTime = getTime(e[1]);
                    if (fromTime + timeInterval == toTime)
                    {
                        observer.OnNext(e[0]);
                        return;
                    }

                    var complementIntervalCount = ((toTime - fromTime).TotalMinutes - 1) / timeInterval.TotalMinutes;
                    observer.OnNext(e[0]);
                    for (int i = 1; i <= complementIntervalCount; i++)
                    {
                        observer.OnNext(createComplement(fromTime.AddMinutes(timeInterval.TotalMinutes * i), e[0]));
                    }
                });

                return () => { };
            });
        }
    }
}