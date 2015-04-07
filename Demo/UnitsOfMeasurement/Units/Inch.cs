/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Inch : IQuantity<double>, IEquatable<Inch>, IComparable<Inch>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Inch.Sense; } }
        public int UnitFamily { get { return Inch.Family; } }
        public double UnitFactor { get { return Inch.Factor; } }
        public string UnitFormat { get { return Inch.Format; } }
        public SymbolCollection UnitSymbol { get { return Inch.Symbol; } }

        #endregion

        #region Constructor(s)
        public Inch(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Inch(double q) { return new Inch(q); }
        public static explicit operator Inch(Foot q) { return new Inch((Inch.Factor / Foot.Factor) * q.Value); }
        public static explicit operator Inch(Yard q) { return new Inch((Inch.Factor / Yard.Factor) * q.Value); }
        public static explicit operator Inch(Mile q) { return new Inch((Inch.Factor / Mile.Factor) * q.Value); }
        public static explicit operator Inch(Kilometer q) { return new Inch((Inch.Factor / Kilometer.Factor) * q.Value); }
        public static explicit operator Inch(Millimeter q) { return new Inch((Inch.Factor / Millimeter.Factor) * q.Value); }
        public static explicit operator Inch(Centimeter q) { return new Inch((Inch.Factor / Centimeter.Factor) * q.Value); }
        public static explicit operator Inch(Meter q) { return new Inch((Inch.Factor / Meter.Factor) * q.Value); }
        public static Inch From(IQuantity<double> q)
        {
            if (q.UnitSense != Inch.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Inch\"", q.GetType().Name));
            return new Inch((Inch.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Inch) && Equals((Inch)obj); }
        public bool /* IEquatable<Inch> */ Equals(Inch other) { return this.Value == other.Value; }
        public int /* IComparable<Inch> */ CompareTo(Inch other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Inch lhs, Inch rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Inch lhs, Inch rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Inch lhs, Inch rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Inch lhs, Inch rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Inch lhs, Inch rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Inch lhs, Inch rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static Inch operator +(Inch lhs, Inch rhs) { return new Inch(lhs.Value + rhs.Value); }
        public static Inch operator -(Inch lhs, Inch rhs) { return new Inch(lhs.Value - rhs.Value); }
        public static Inch operator ++(Inch q) { return new Inch(q.Value + 1d); }
        public static Inch operator --(Inch q) { return new Inch(q.Value - 1d); }
        public static Inch operator -(Inch q) { return new Inch(-q.Value); }
        public static Inch operator *(double lhs, Inch rhs) { return new Inch(lhs * rhs.Value); }
        public static Inch operator *(Inch lhs, double rhs) { return new Inch(lhs.Value * rhs); }
        public static Inch operator /(Inch lhs, double rhs) { return new Inch(lhs.Value / rhs); }
        // Outer:
        public static double operator /(Inch lhs, Inch rhs) { return lhs.Value / rhs.Value; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Inch.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Inch.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Inch.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = 0;
        private static double s_factor = 100d * Meter.Factor / 2.54d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("in");

        private static readonly Inch s_one = new Inch(1d);
        private static readonly Inch s_zero = new Inch(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Inch One { get { return s_one; } }
        public static Inch Zero { get { return s_zero; } }
        #endregion
    }
}