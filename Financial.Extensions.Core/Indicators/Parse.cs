﻿//==============================================================================
// Copyright (c) 2013-2019 Fiats Inc. All rights reserved.
// https://www.fiats.asia/feedex/
//

using System;
using System.Reactive.Linq;

namespace Financial.Extensions
{
    public static partial class Indicators
    {
        // Expected format for indicator string is:
        // "EMA:5" - colon is separator between name and parameter
        public static IObservable<object> ParseIndicator(this IObservable<object> source, string str)
        {
            var name = str.Split(':')[0];
            var parameters = str.Replace(name + ":", "");

            switch (name)
            {
                case "SMA":
                case "SimpleMovingAverage":
                    return source.Cast<double>().SimpleMovingAverage(int.Parse(parameters)).Select(e => (object)e);

                case "EMA":
                case "ExponentialMovingAverage":
                    return source.Cast<double>().ExponentialMovingAverage(int.Parse(parameters)).Select(e => (object)e);

                case "MMA":
                case "ModifiedMovingAverage":
                    return source.Cast<double>().ModifiedMovingAverage(int.Parse(parameters)).Select(e => (object)e);

                case "ADL":
                case "AccumulationDistribution":
                    return source.Cast<IFxOhlcv>().AccumulationDistribution().Select(e => (object)e);
            }

            return null;
        }
    }
}
