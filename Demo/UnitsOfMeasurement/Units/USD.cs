/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct USD : IQuantity<decimal>, IEquatable<USD>, IComparable<USD>
	{
		#region Fields
		private readonly decimal m_value;
		#endregion

		#region Properties

		// instance properties
		public decimal Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return USD.Sense; } }
		public int UnitFamily { get { return USD.Family; } }
		public decimal UnitFactor { get { return USD.Factor; } }
		public string UnitFormat { get { return USD.Format; } }
		public SymbolCollection UnitSymbol { get { return USD.Symbol; } }

		#endregion

		#region Constructor(s)
		public USD(decimal value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator USD(decimal q) { return new USD(q); }
		public static explicit operator USD(EUR q) { return new USD((USD.Factor / EUR.Factor) * q.Value); }
		public static explicit operator USD(PLN q) { return new USD((USD.Factor / PLN.Factor) * q.Value); }
		public static explicit operator USD(GBP q) { return new USD((USD.Factor / GBP.Factor) * q.Value); }
        public static USD From(IQuantity<decimal> q)
        {
			if (q.UnitSense != USD.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"USD\"", q.GetType().Name));
			return new USD((USD.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is USD) && Equals((USD)obj); }
		public bool /* IEquatable<USD> */ Equals(USD other) { return this.Value == other.Value; }
		public int /* IComparable<USD> */ CompareTo(USD other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(USD lhs, USD rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(USD lhs, USD rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(USD lhs, USD rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(USD lhs, USD rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(USD lhs, USD rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(USD lhs, USD rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static USD operator +(USD lhs, USD rhs) { return new USD(lhs.Value + rhs.Value); }
		public static USD operator -(USD lhs, USD rhs) { return new USD(lhs.Value - rhs.Value); }
		public static USD operator ++(USD q) { return new USD(q.Value + decimal.One); }
		public static USD operator --(USD q) { return new USD(q.Value - decimal.One); }
		public static USD operator -(USD q) { return new USD(-q.Value); }
		public static USD operator *(decimal lhs, USD rhs) { return new USD(lhs * rhs.Value); }
		public static USD operator *(USD lhs, decimal rhs) { return new USD(lhs.Value * rhs); }
		public static USD operator /(USD lhs, decimal rhs) { return new USD(lhs.Value / rhs); }
		// Outer:
		public static decimal operator /(USD lhs, USD rhs) { return lhs.Value / rhs.Value; }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, USD.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, USD.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, USD.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = EUR.Sense;
		private static readonly int s_family = 23;
		private static decimal s_factor = 1.3433m * EUR.Factor;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("USD");

		private static readonly USD s_one = new USD(decimal.One);
		private static readonly USD s_zero = new USD(decimal.Zero);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static USD One { get { return s_one; } }
		public static USD Zero { get { return s_zero; } }
		#endregion
	}
}
