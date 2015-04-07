/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Millimeter : IQuantity<double>, IEquatable<Millimeter>, IComparable<Millimeter>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Millimeter.Sense; } }
        public int UnitFamily { get { return Millimeter.Family; } }
        public double UnitFactor { get { return Millimeter.Factor; } }
        public string UnitFormat { get { return Millimeter.Format; } }
        public SymbolCollection UnitSymbol { get { return Millimeter.Symbol; } }

        #endregion

        #region Constructor(s)
        public Millimeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Millimeter(double q) { return new Millimeter(q); }
        public static explicit operator Millimeter(Centimeter q) { return new Millimeter((Millimeter.Factor / Centimeter.Factor) * q.Value); }
        public static explicit operator Millimeter(Meter q) { return new Millimeter((Millimeter.Factor / Meter.Factor) * q.Value); }
        public static explicit operator Millimeter(Inch q) { return new Millimeter((Millimeter.Factor / Inch.Factor) * q.Value); }
        public static explicit operator Millimeter(Foot q) { return new Millimeter((Millimeter.Factor / Foot.Factor) * q.Value); }
        public static explicit operator Millimeter(Yard q) { return new Millimeter((Millimeter.Factor / Yard.Factor) * q.Value); }
        public static explicit operator Millimeter(Mile q) { return new Millimeter((Millimeter.Factor / Mile.Factor) * q.Value); }
        public static explicit operator Millimeter(Kilometer q) { return new Millimeter((Millimeter.Factor / Kilometer.Factor) * q.Value); }
        public static Millimeter From(IQuantity<double> q)
        {
            if (q.UnitSense != Millimeter.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Millimeter\"", q.GetType().Name));
            return new Millimeter((Millimeter.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Millimeter) && Equals((Millimeter)obj); }
        public bool /* IEquatable<Millimeter> */ Equals(Millimeter other) { return this.Value == other.Value; }
        public int /* IComparable<Millimeter> */ CompareTo(Millimeter other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Millimeter lhs, Millimeter rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Millimeter lhs, Millimeter rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Millimeter lhs, Millimeter rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Millimeter lhs, Millimeter rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Millimeter lhs, Millimeter rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Millimeter lhs, Millimeter rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static Millimeter operator +(Millimeter lhs, Millimeter rhs) { return new Millimeter(lhs.Value + rhs.Value); }
        public static Millimeter operator -(Millimeter lhs, Millimeter rhs) { return new Millimeter(lhs.Value - rhs.Value); }
        public static Millimeter operator ++(Millimeter q) { return new Millimeter(q.Value + 1d); }
        public static Millimeter operator --(Millimeter q) { return new Millimeter(q.Value - 1d); }
        public static Millimeter operator -(Millimeter q) { return new Millimeter(-q.Value); }
        public static Millimeter operator *(double lhs, Millimeter rhs) { return new Millimeter(lhs * rhs.Value); }
        public static Millimeter operator *(Millimeter lhs, double rhs) { return new Millimeter(lhs.Value * rhs); }
        public static Millimeter operator /(Millimeter lhs, double rhs) { return new Millimeter(lhs.Value / rhs); }
        // Outer:
        public static double operator /(Millimeter lhs, Millimeter rhs) { return lhs.Value / rhs.Value; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Millimeter.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Millimeter.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Millimeter.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = 0;
        private static double s_factor = 1000d * Meter.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mm");

        private static readonly Millimeter s_one = new Millimeter(1d);
        private static readonly Millimeter s_zero = new Millimeter(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Millimeter One { get { return s_one; } }
        public static Millimeter Zero { get { return s_zero; } }
        #endregion
    }
}