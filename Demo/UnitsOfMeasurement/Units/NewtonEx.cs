﻿/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

namespace Demo.UnitsOfMeasurement
{
    public partial struct Newton
    {
        public static NewtonMeter operator ^(Newton lhs, Meter rhs) { return new NewtonMeter(lhs.m_value * rhs.m_value); }
        public static NewtonMeter operator ^(Meter lhs, Newton rhs) { return new NewtonMeter(lhs.m_value * rhs.m_value); }
    }
}
