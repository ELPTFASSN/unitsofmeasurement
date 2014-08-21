/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Mile : IQuantity<double>, IEquatable<Mile>, IComparable<Mile>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Mile.Sense; } }
        public int UnitFamily { get { return Mile.Family; } }
        public double UnitFactor { get { return Mile.Factor; } }
        public string UnitFormat { get { return Mile.Format; } }
        public SymbolCollection UnitSymbol { get { return Mile.Symbol; } }

        #endregion

        #region Constructor(s)
        public Mile(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Mile(double q) { return new Mile(q); }
        public static explicit operator Mile(Kilometer q) { return new Mile((Mile.Factor / Kilometer.Factor) * q.Value); }
        public static explicit operator Mile(Millimeter q) { return new Mile((Mile.Factor / Millimeter.Factor) * q.Value); }
        public static explicit operator Mile(Centimeter q) { return new Mile((Mile.Factor / Centimeter.Factor) * q.Value); }
        public static explicit operator Mile(Meter q) { return new Mile((Mile.Factor / Meter.Factor) * q.Value); }
        public static explicit operator Mile(Inch q) { return new Mile((Mile.Factor / Inch.Factor) * q.Value); }
        public static explicit operator Mile(Foot q) { return new Mile((Mile.Factor / Foot.Factor) * q.Value); }
        public static explicit operator Mile(Yard q) { return new Mile((Mile.Factor / Yard.Factor) * q.Value); }
        public static Mile From(IQuantity<double> q)
        {
            if (q.UnitSense != Mile.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Mile\"", q.GetType().Name));
            return new Mile((Mile.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Mile) && Equals((Mile)obj); }
        public bool /* IEquatable<Mile> */ Equals(Mile other) { return this.Value == other.Value; }
        public int /* IComparable<Mile> */ CompareTo(Mile other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Mile lhs, Mile rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Mile lhs, Mile rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Mile lhs, Mile rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Mile lhs, Mile rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Mile lhs, Mile rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Mile lhs, Mile rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static Mile operator +(Mile lhs, Mile rhs) { return new Mile(lhs.Value + rhs.Value); }
        public static Mile operator -(Mile lhs, Mile rhs) { return new Mile(lhs.Value - rhs.Value); }
        public static Mile operator ++(Mile q) { return new Mile(q.Value + 1d); }
        public static Mile operator --(Mile q) { return new Mile(q.Value - 1d); }
        public static Mile operator -(Mile q) { return new Mile(-q.Value); }
        public static Mile operator *(double lhs, Mile rhs) { return new Mile(lhs * rhs.Value); }
        public static Mile operator *(Mile lhs, double rhs) { return new Mile(lhs.Value * rhs); }
        public static Mile operator /(Mile lhs, double rhs) { return new Mile(lhs.Value / rhs); }
        // Outer:
        public static double operator /(Mile lhs, Mile rhs) { return lhs.Value / rhs.Value; }
        public static MPH operator /(Mile lhs, Hour rhs) { return new MPH(lhs.Value / rhs.Value); }
        public static Hour operator /(Mile lhs, MPH rhs) { return new Hour(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Mile.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Mile.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Mile.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Yard.Sense;
        private static readonly int s_family = 0;
        private static double s_factor = Yard.Factor / 1760d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mil");

        private static readonly Mile s_one = new Mile(1d);
        private static readonly Mile s_zero = new Mile(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Mile One { get { return s_one; } }
        public static Mile Zero { get { return s_zero; } }
        #endregion
    }
}
