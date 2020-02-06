﻿//==============================================================================
// Copyright (c) 2017-2019 Fiats Inc. All rights reserved.
// https://www.fiats.asia/
//

namespace Financial.Extensions
{
    // Based on ISO4217
    public enum FxCurrencyCode
    {
        AUD = 36,  // Australian dollar
        CNY = 156, // Yuan Renminbi
        HKD = 344, // Hong Kong dollar
        JPY = 392, // Japanese yen
        KRW = 410, // Source Korean won
        SGD = 702, // Singapore dollar
        ZAR = 710, // South african Rand
        THB = 764, // Thai baht
        RUR = 810, // Russian Ruble
        GBP = 826, // Pound sterling
        USD = 840, // United States dollar
        EUR = 978, // Euro

        CryptoAssetCodeBaseNumber = 10000,
    }

    public enum FxCryptoAssetCode
    {
        BaseNumber = FxCurrencyCode.CryptoAssetCodeBaseNumber,

        // Crypto assets
        BTC, XBT = BTC, // Bitcoin
        BCH, XBC = BCH, // Bitcoin Cash
        ETH,            // Ether
        ETC,
        LTC,
        MONA,
        LSK,
        XRP,            // Ripple
    }
}