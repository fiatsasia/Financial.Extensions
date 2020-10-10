﻿//==============================================================================
// Copyright (c) 2017-2020 Fiats Inc. All rights reserved.
// https://www.fiats.asia/
//

namespace Financier.Trading
{
    public enum OrderTransactionState
    {
        Idle,

        Ordering,
        ConfirmingOrder,

        Canceling,
        CancelAccepted,

        Closed,
    }
}
