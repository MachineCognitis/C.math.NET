
#region "COPYRIGHT 2016, Robert Baron (robert.baron@videotron.ca)"
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
#endregion

using System;

// Declare assembly as CLS compliant.
[assembly: System.CLSCompliant(true)]

namespace C
{
    /// <summary>
    /// Represents <c>static</c> methods for manipulating IEEE-754 floating-point numbers.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class currently supports both double and single precision floating-point numbers.
    /// </para>
    /// </remarks>
    /// <author email="robert.baron@videotron.ca">Robert Baron</author>
    public sealed class math
    {

        /// <summary>
        /// Constructor is declared <c>private</c> because all members are <c>static</c>.
        /// </summary>
        /// <remarks></remarks>
        private math()
        {
        }

        #region "The values returned by 'ilogb' for 0 and NaN respectively."

        public const int FP_ILOGB0 = (-2147483647);
        public const int FP_ILOGBNAN = (2147483647);
        public const int INT_MAX = (32767);

        #endregion

        #region "Floating-point number categories."

        public const int FP_NORMAL = 0;
        public const int FP_SUBNORMAL = 1;
        public const int FP_ZERO = 2;
        public const int FP_INFINITE = 3;
        public const int FP_NAN = 4;

        #endregion

        #region "Properties of floating-point types."

        public const int DBL_EXP_BIAS = 1023;   // The exponent bias (value to subtract from the stored exponent to get the real exponent).
        public const int DBL_EXP_BITS = 11;     // The number of bits in the exponent.
        public const int DBL_EXP_MAX = 1023;
        public const int DBL_EXP_MIN = -1022;
        public const long DBL_EXP_CLR_MASK = DBL_SGN_MASK | DBL_MANT_MASK;
        public const long DBL_EXP_MASK = 0x7ff0000000000000L;
        public const int DBL_MANT_BITS = 52;    // The number of bits in the mantissa (excludes the implicit leading <c>1</c> bit of normalized floating-point numbers).
        public const long DBL_MANT_CLR_MASK = DBL_SGN_MASK | DBL_EXP_MASK;
        public const long DBL_MANT_MASK = 0x000fffffffffffffL;
        public const double DBL_MAX = System.Double.MaxValue;           // Maximum normal.
        public const double DBL_MIN = 2.2250738585072014e-308D;         // Minimum normal.
        public const double DBL_DENORM_MAX = DBL_MIN - DBL_DENORM_MIN;  // Maximum subnormal.
        public const double DBL_DENORM_MIN = System.Double.Epsilon;     // Minimum subnormal.
        public const long DBL_SGN_CLR_MASK = 0x7fffffffffffffffL;
        public const long DBL_SGN_MASK = -1 - 0x7fffffffffffffffL;

        public const int FLT_EXP_BIAS = 127;    // The exponent bias (value to subtract from the stored exponent to get the real exponent).
        public const int FLT_EXP_BITS = 8;      // The number of bits in the exponent.
        public const int FLT_EXP_MAX = 127;
        public const int FLT_EXP_MIN = -126;
        public const int FLT_EXP_CLR_MASK = FLT_SGN_MASK | FLT_MANT_MASK;
        public const int FLT_EXP_MASK = 0x7f800000;
        public const int FLT_MANT_BITS = 23;    // The number of bits in the mantissa (excludes the implicit leading <c>1</c> bit of normalized floating-point numbers).
        public const int FLT_MANT_CLR_MASK = FLT_SGN_MASK | FLT_EXP_MASK;
        public const int FLT_MANT_MASK = 0x007fffff;
        public const float FLT_MAX = System.Single.MaxValue;            // Maximum normal.
        public const float FLT_MIN = 1.17549435e-38F;                   // Minimum normal.
        public const float FLT_DENORM_MAX = FLT_MIN - FLT_DENORM_MIN;   // Maximum subnormal.
        public const float FLT_DENORM_MIN = System.Single.Epsilon;      // Minimum subnormal.
        public const int FLT_SGN_CLR_MASK = 0x7fffffff;
        public const int FLT_SGN_MASK = -1 - 0x7fffffff;

        #endregion

        #region "Classification."

        #region "fpclassify"

        /// <summary>
        /// Categorizes the given floating point <paramref name="number"/> into the categories: zero, subnormal, normal, infinite or NAN.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>One of <see cref="math.FP_INFINITE"/>, <see cref="math.FP_NAN"/>, <see cref="math.FP_NORMAL"/>, <see cref="math.FP_SUBNORMAL"/> or <see cref="math.FP_ZERO"/>, specifying the category of <paramref name="number"/>.</returns>
        /// <remarks></remarks>
        public static int fpclassify(double number)
        {
            long bits = System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_CLR_MASK;
            if (bits >= 0x7ff0000000000000L)
                return (bits & math.DBL_MANT_MASK) == 0 ? math.FP_INFINITE : math.FP_NAN;
            else if (bits < 0x0010000000000000L)
                return bits == 0 ? math.FP_ZERO : math.FP_SUBNORMAL;
            return math.FP_NORMAL;
        }

        /// <summary>
        /// Categorizes the given floating point <paramref name="number"/> into the categories: zero, subnormal, normal, infinite or NAN.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>One of <see cref="math.FP_INFINITE"/>, <see cref="math.FP_NAN"/>, <see cref="math.FP_NORMAL"/>, <see cref="math.FP_SUBNORMAL"/> or <see cref="math.FP_ZERO"/>, specifying the category of <paramref name="number"/>.</returns>
        /// <remarks></remarks>
        public static int fpclassify(float number)
        {
            int bits = SingleToInt32Bits(number) & math.FLT_SGN_CLR_MASK;
            if (bits >= 0x7f800000)
                return (bits & math.FLT_MANT_MASK) == 0 ? math.FP_INFINITE : math.FP_NAN;
            else if (bits < 0x00800000)
                return bits == 0 ? math.FP_ZERO : math.FP_SUBNORMAL;
            return math.FP_NORMAL;
        }

        #endregion

        #region "isfinite"

        /// <summary>
        /// Checks if the given <paramref name="number"/> has finite value.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns><c>true</c> if <paramref name="number"/> is finite, <c>false</c> otherwise.</returns>
        /// <remarks>
        /// <para>
        /// A floating-point number is finite if it zero, normal, or subnormal, but not infinite or NaN.
        /// </para>
        /// </remarks>
        public static bool isfinite(double number)
        {
            // Check the exponent part. If it is all 1's then we have infinity/NaN, i.e., not a finite value.
            return (System.BitConverter.DoubleToInt64Bits(number) & math.DBL_EXP_MASK) != math.DBL_EXP_MASK;
        }

        /// <summary>
        /// Checks if the given <paramref name="number"/> has finite value.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns><c>true</c> if <paramref name="number"/> is finite, <c>false</c> otherwise.</returns>
        /// <remarks>
        /// <para>
        /// A floating-point number is finite if it zero, normal, or subnormal, but not infinite or NaN.
        /// </para>
        /// </remarks>
        public static bool isfinite(float number)
        {
            // Check the exponent part. If it is all 1's then we have infinity/NaN, i.e., not a finite value.
            return (SingleToInt32Bits(number) & math.FLT_EXP_MASK) != math.FLT_EXP_MASK;
        }

        #endregion

        #region "isinf"

        /// <summary>
        /// Checks if the given <paramref name="number"/> is positive or negative infinity.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns><c>true</c> if <paramref name="number"/> has an infinite value, <c>false</c> otherwise.</returns>
        /// <remarks></remarks>
        public static bool isinf(double number)
        {
            return (System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_CLR_MASK) == 0x7ff0000000000000L;
        }

        /// <summary>
        /// Checks if the given <paramref name="number"/> is positive or negative infinity.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns><c>true</c> if <paramref name="number"/> has an infinite value, <c>false</c> otherwise.</returns>
        /// <remarks></remarks>
        public static bool isinf(float number)
        {
            return (SingleToInt32Bits(number) & math.FLT_SGN_CLR_MASK) == 0x7f800000;
        }

        #endregion

        #region "isnan"

        /// <summary>
        /// Checks if the given <paramref name="number"/> is NaN (Not A Number).
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns><c>true</c> if <paramref name="number"/> is NaN, <c>false</c> otherwise.</returns>
        /// <remarks></remarks>
        public static bool isnan(double number)
        {
            return (System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_CLR_MASK) > 0x7ff0000000000000L;
        }

        /// <summary>
        /// Checks if the given <paramref name="number"/> is NaN (Not A Number).
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns><c>true</c> if <paramref name="number"/> is NaN, <c>false</c> otherwise.</returns>
        /// <remarks></remarks>
        public static bool isnan(float number)
        {
            return (SingleToInt32Bits(number) & math.FLT_SGN_CLR_MASK) > 0x7f800000;
        }

        #endregion

        #region "isnormal"

        /// <summary>
        /// Checks if the given <paramref name="number"/> is normal.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns><c>true</c> if <paramref name="number"/> is normal, <c>false</c> otherwise.</returns>
        /// <remarks>
        /// <para>
        /// A floating-point number is normal if it is neither zero, subnormal, normal, nor NaN.
        /// </para>
        /// </remarks>
        public static bool isnormal(double number)
        {
            long bits = System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_CLR_MASK;
            // Not infinity or NaN and greater than zero or subnormal.
            return (bits < 0x7ff0000000000000L) && (bits >= 0x0010000000000000L);
        }

        /// <summary>
        /// Checks if the given <paramref name="number"/> is normal.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns><c>true</c> if <paramref name="number"/> is normal, <c>false</c> otherwise.</returns>
        /// <remarks>
        /// <para>
        /// A floating-point number is normal if it is neither zero, subnormal, normal, nor NaN.
        /// </para>
        /// </remarks>
        public static bool isnormal(float number)
        {
            int bits = SingleToInt32Bits(number) & math.FLT_SGN_CLR_MASK;
            // Not infinity or NaN and greater than zero or subnormal.
            return (bits < 0x7f800000) && (bits >= 0x00800000);
        }

        #endregion

        #region "signbit"

        /// <summary>
        /// Gets the sign bit of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The sign bit of the specified floating-point <paramref name="number"/>.</returns>
        /// <remarks>
        /// <para>
        /// The function detects the sign bit of zeroes, infinities, and NaN. Along with
        /// <see cref="math.copysign(double, double)"/>, <see cref="math.signbit(double)"/> is one
        /// of the only two portable ways to examine the sign of NaN. 
        /// </para>
        /// </remarks>
        public static int signbit(double number)
        {
            if (System.Double.IsNaN(number))
                return ((System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_MASK) != 0) ? 0 : 1;
            else
                return ((System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_MASK) != 0) ? 1 : 0;
        }

        /// <summary>
        /// Gets the sign bit of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The sign bit of the specified floating-point <paramref name="number"/>.</returns>
        /// <remarks>
        /// <para>
        /// The function detects the sign bit of zeroes, infinities, and NaN. Along with
        /// <see cref="math.copysign(float, float)"/>, <see cref="math.signbit(float)"/> is one
        /// of the only two portable ways to examine the sign of NaN. 
        /// </para>
        /// </remarks>
        public static int signbit(float number)
        {
            if (System.Double.IsNaN(number))
                return ((SingleToInt32Bits(number) & math.FLT_SGN_MASK) != 0) ? 0 : 1;
            else
                return ((SingleToInt32Bits(number) & math.FLT_SGN_MASK) != 0) ? 1 : 0;
        }

        #endregion

        #endregion

        #region "Exponential and logarithmic functions."

        #region "frexp"

        /// <summary>
        /// Decomposes the given floating-point <paramref name="number"/> into a normalized fraction and an integral power of two.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <param name="exponent">Reference to an <see cref="int"/> value to store the exponent to.</param>
        /// <returns>A fraction in the range <c>[0.5, 1)</c> so that <c><paramref name="number"/> = fraction * 2^<paramref name="exponent"/></c>.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="number"/> is <c>±0</c>, it is returned, and <c>0</c> is returned in <paramref name="exponent"/>.
        /// If <paramref name="number"/> is infinite, it is returned, and an undefined value is returned in <paramref name="exponent"/>.
        /// If <paramref name="number"/> is NaN, it is returned, and an undefined value is returned in <paramref name="exponent"/>.
        /// </para>
        /// <para>
        /// The function <see cref="math.frexp(double, ref int)"/>, together with its dual, <see cref="math.ldexp(double, int)"/>,
        /// can be used to manipulate the representation of a floating-point number without direct bit manipulations.
        /// </para>
        /// <para>
        /// The relation of <see cref="math.frexp(double, ref int)"/> to <see cref="math.logb(double)"/> and <see cref="math.scalbn(double, int)"/> is:
        /// </para>
        /// <para>
        /// <c><paramref name="exponent"/> = (<paramref name="number"/> == 0) ? 0 : (int)(1 + <see cref="math.logb(double)"/>(<paramref name="number"/>))</c><br/>
        /// <c>fraction = <see cref="math.scalbn(double, int)"/>(<paramref name="number"/>, -<paramref name="exponent"/>)</c>
        /// </para>
        /// </remarks>
        public static double frexp(double number, ref int exponent)
        {
            long bits = System.BitConverter.DoubleToInt64Bits(number);
            int exp = (int)((bits & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS);
            exponent = 0;

            if (exp == 0x7ff || number == 0D)
                number += number;
            else
            {
                // Not zero and finite.
                exponent = exp - 1022;
                if (exp == 0)
                {
                    // Subnormal, scale number so that it is in [1, 2).
                    number *= System.BitConverter.Int64BitsToDouble(0x4350000000000000L); // 2^54
                    bits = System.BitConverter.DoubleToInt64Bits(number);
                    exp = (int)((bits & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS);
                    exponent = exp - 1022 - 54;
                }
                // Set exponent to -1 so that number is in [0.5, 1).
                number = System.BitConverter.Int64BitsToDouble((bits & math.DBL_EXP_CLR_MASK) | 0x3fe0000000000000L);
            }

            return number;
        }

        /// <summary>
        /// Decomposes the given floating-point <paramref name="number"/> into a normalized fraction and an integral power of two.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <param name="exponent">Reference to an <see cref="int"/> value to store the exponent to.</param>
        /// <returns>A fraction in the range <c>[0.5, 1)</c> so that <c><paramref name="number"/> = fraction * 2^<paramref name="exponent"/></c>.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="number"/> is <c>±0</c>, it is returned, and <c>0</c> is returned in <paramref name="exponent"/>.
        /// If <paramref name="number"/> is infinite, it is returned, and an undefined value is returned in <paramref name="exponent"/>.
        /// If <paramref name="number"/> is NaN, it is returned, and an undefined value is returned in <paramref name="exponent"/>.
        /// </para>
        /// <para>
        /// The function <see cref="math.frexp(float, ref int)"/>, together with its dual, <see cref="math.ldexp(float, int)"/>,
        /// can be used to manipulate the representation of a floating-point number without direct bit manipulations.
        /// </para>
        /// <para>
        /// The relation of <see cref="math.frexp(float, ref int)"/> to <see cref="math.logb(float)"/> and <see cref="math.scalbn(float, int)"/> is:
        /// </para>
        /// <para>
        /// <c><paramref name="exponent"/> = (<paramref name="number"/> == 0) ? 0 : (int)(1 + <see cref="math.logb(float)"/>(<paramref name="number"/>))</c><br/>
        /// <c>fraction = <see cref="math.scalbn(float, int)"/>(<paramref name="number"/>, -<paramref name="exponent"/>)</c>
        /// </para>
        /// </remarks>
        public static float frexp(float number, ref int exponent)
        {
            int bits = math.SingleToInt32Bits(number);
            int exp = (int)((bits & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS);
            exponent = 0;

            if (exp == 0xff || number == 0F)
                number += number;
            else
            {
                // Not zero and finite.
                exponent = exp - 126;
                if (exp == 0)
                {
                    // Subnormal, scale number so that it is in [1, 2).
                    number *= math.Int32BitsToSingle(0x4c000000); // 2^25
                    bits = math.SingleToInt32Bits(number);
                    exp = (int)((bits & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS);
                    exponent = exp - 126 - 25;
                }
                // Set exponent to -1 so that number is in [0.5, 1).
                number = math.Int32BitsToSingle((bits & math.FLT_EXP_CLR_MASK) | 0x3f000000);
            }

            return number;
        }

        #endregion

        #region "ilogb"

        /// <summary>
        /// Gets the unbiased exponent of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The unbiased exponent of the specified floating-point <paramref name="number"/>, or a special value if <paramref name="number"/> is not normal or subnormal.</returns>
        /// <remarks>
        /// <para>
        /// The unbiased exponent is the integral part of the logarithm base 2 of <paramref name="number"/>.
        /// The unbiased exponent is such that
        /// <c><paramref name="number"/> = <see cref="math.significand(double)"/>(<paramref name="number"/>) * 2^<see cref="math.logb(double)"/>(<paramref name="number"/>)</c>.
        /// The return unbiased exponent is valid for all normal and subnormal numbers.
        /// If <paramref name="number"/> is <c>±0</c>, <see cref="math.FP_ILOGB0"/> is returned.
        /// If <paramref name="number"/> is infinite, <see cref="math.INT_MAX"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="math.FP_ILOGBNAN"/> is returned.
        /// </para>
        /// <para>
        /// If <paramref name="number"/> is not zero, infinite, or NaN, the value returned is exactly equivalent to
        /// <c>(<see cref="int"/>)<see cref="math.logb(double)"/>(<paramref name="number"/>)</c>. 
        /// </para>
        /// <para>
        /// The value of the exponent returned by <see cref="math.ilogb(double)"/> is always <c>1</c> less than the exponent retuned by
        /// <see cref="math.frexp(double, ref int)"/> because of the different normalization requirements:
        /// for <see cref="math.ilogb(double)"/>, the normalized significand is in the interval <c>[1, 2)</c>,
        /// but for <see cref="math.frexp(double, ref int)"/>, the normalized significand is in the interval <c>[0.5, 1)</c>.
        /// </para>
        /// </remarks>
        public static int ilogb(double number)
        {
            long bits = System.BitConverter.DoubleToInt64Bits(number) & (math.DBL_EXP_MASK | math.DBL_MANT_MASK);
            if (bits == 0L)
                return math.FP_ILOGB0;
            int exp = (int)(bits >> math.DBL_MANT_BITS);
            if (exp == 0x7ff)
                return (bits & math.DBL_MANT_MASK) == 0L ? math.INT_MAX : math.FP_ILOGBNAN;
            if (exp == 0)
                exp -= (_leadingZeroesCount(bits) - (DBL_EXP_BITS + 1));
            return exp - math.DBL_EXP_BIAS;
        }

        /// <summary>
        /// Gets the unbiased exponent of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The unbiased exponent of the specified floating-point <paramref name="number"/>, or a special value if <paramref name="number"/> is not normal or subnormal.</returns>
        /// <remarks>
        /// <para>
        /// The unbiased exponent is the integral part of the logarithm base 2 of <paramref name="number"/>.
        /// The unbiased exponent is such that
        /// <c><paramref name="number"/> = <see cref="math.significand(float)"/>(<paramref name="number"/>) * 2^<see cref="math.logb(float)"/>(<paramref name="number"/>)</c>.
        /// The return unbiased exponent is valid for all normal and subnormal numbers.
        /// If <paramref name="number"/> is <c>±0</c>, <see cref="math.FP_ILOGB0"/> is returned.
        /// If <paramref name="number"/> is infinite, <see cref="math.INT_MAX"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="math.FP_ILOGBNAN"/> is returned.
        /// </para>
        /// <para>
        /// If <paramref name="number"/> is not zero, infinite, or NaN, the value returned is exactly equivalent to
        /// <c>(<see cref="int"/>)<see cref="math.logb(float)"/>(<paramref name="number"/>)</c>. 
        /// </para>
        /// <para>
        /// The value of the exponent returned by <see cref="math.ilogb(float)"/> is always <c>1</c> less than the exponent retuned by
        /// <see cref="math.frexp(float, ref int)"/> because of the different normalization requirements:
        /// for <see cref="math.ilogb(float)"/>, the normalized significand is in the interval <c>[1, 2)</c>,
        /// but for <see cref="math.frexp(float, ref int)"/>, the normalized significand is in the interval <c>[0.5, 1)</c>. 
        /// </para>
        /// </remarks>
        public static int ilogb(float number)
        {
            int bits = math.SingleToInt32Bits(number) & (math.FLT_EXP_MASK | math.FLT_MANT_MASK);
            if (bits == 0L)
                return math.FP_ILOGB0;
            int exp = (bits >> math.FLT_MANT_BITS);
            if (exp == 0xff)
                return (bits & math.FLT_MANT_MASK) == 0L ? math.INT_MAX : math.FP_ILOGBNAN;
            if (exp == 0)
                exp -= (_leadingZeroesCount(bits) - (FLT_EXP_BITS + 1));
            return exp - math.FLT_EXP_BIAS;
        }

        #endregion

        #region "ldexp"

        /// <summary>
        /// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <param name="exponent">The exponent of the power of two.</param>
        /// <returns>The value <paramref name="number"/> time 2^<paramref name="exponent"/>.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="number"/> is <c>±0</c>, it is returned.
        /// If <paramref name="number"/> is infinite, it is returned.
        /// If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.
        /// </para>
        /// <para>
        /// The function <see cref="math.ldexp(double, int)"/> ("load exponent"), together with its dual, <see cref="math.frexp(double, ref int)"/>,
        /// can be used to manipulate the representation of a floating-point number without direct bit manipulations.
        /// </para>
        /// <para>
        /// The function <see cref="math.ldexp(double, int)"/> is equivalent to <see cref="math.scalbn(double, int)"/>.
        /// </para>
        /// </remarks>
        public static double ldexp(double number, int exponent)
        {
            return scalbn(number, exponent);
        }

        /// <summary>
        /// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <param name="exponent">The exponent of the power of two.</param>
        /// <returns>The value <paramref name="number"/> time 2^<paramref name="exponent"/>.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="number"/> is <c>±0</c>, it is returned.
        /// If <paramref name="number"/> is infinite, it is returned.
        /// If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.
        /// </para>
        /// <para>
        /// The function <see cref="math.ldexp(float, int)"/> ("load exponent"), together with its dual, <see cref="math.frexp(float, ref int)"/>,
        /// can be used to manipulate the representation of a floating-point number without direct bit manipulations.
        /// </para>
        /// <para>
        /// The function <see cref="math.ldexp(float, int)"/> is equivalent to <see cref="math.scalbn(float, int)"/>.
        /// </para>
        /// </remarks>
        public static float ldexp(float number, int exponent)
        {
            return scalbn(number, exponent);
        }

        #endregion

        #region "logb"

        /// <summary>
        /// Gets the unbiased exponent of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The unbiased exponent of the specified floating-point <paramref name="number"/>, or a special value if <paramref name="number"/> is not normal or subnormal.</returns>
        /// <remarks>
        /// <para>
        /// The unbiased exponent is the integral part of the logarithm base 2 of <paramref name="number"/>.
        /// The unbiased exponent is such that
        /// <c><paramref name="number"/> = <see cref="math.significand(double)"/>(<paramref name="number"/>) * 2^<see cref="math.logb(double)"/>(<paramref name="number"/>)</c>.
        /// The return unbiased exponent is valid for all normal and subnormal numbers.
        /// If <paramref name="number"/> is <c>±0</c>, <see cref="System.Double.NegativeInfinity"/> is returned.
        /// If <paramref name="number"/> is infinite, <see cref="System.Double.PositiveInfinity"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.
        /// </para>
        /// <para>
        /// The value of the exponent returned by <see cref="math.logb(double)"/> is always <c>1</c> less than the exponent retuned by
        /// <see cref="math.frexp(double, ref int)"/> because of the different normalization requirements:
        /// for <see cref="math.logb(double)"/>, the normalized significand is in the interval <c>[1, 2)</c>,
        /// but for <see cref="math.frexp(double, ref int)"/>, the normalized significand is in the interval <c>[0.5, 1)</c>. 
        /// </para>
        /// </remarks>
        public static double logb(double number)
        {
            int exp = math.ilogb(number);
            switch (exp)
            {
                case math.FP_ILOGB0:
                    return System.Double.NegativeInfinity;
                case math.FP_ILOGBNAN:
                    return System.Double.NaN;
                case math.INT_MAX:
                    return System.Double.PositiveInfinity;
            }
            return exp;
        }

        /// <summary>
        /// Gets the unbiased exponent of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The unbiased exponent of the specified floating-point <paramref name="number"/>, or a special value if <paramref name="number"/> is not normal or subnormal.</returns>
        /// <remarks>
        /// <para>
        /// The unbiased exponent is the integral part of the logarithm base 2 of <paramref name="number"/>.
        /// The unbiased exponent is such that
        /// <c><paramref name="number"/> = <see cref="math.significand(float)"/>(<paramref name="number"/>) * 2^<see cref="math.logb(float)"/>(<paramref name="number"/>)</c>.
        /// The return unbiased exponent is valid for all normal and subnormal numbers.
        /// If <paramref name="number"/> is <c>±0</c>, <see cref="System.Single.NegativeInfinity"/> is returned.
        /// If <paramref name="number"/> is infinite, <see cref="System.Single.PositiveInfinity"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="System.Single.NaN"/> is returned.
        /// </para>
        /// <para>
        /// The value of the exponent returned by <see cref="math.logb(float)"/> is always <c>1</c> less than the exponent retuned by
        /// <see cref="math.frexp(float, ref int)"/> because of the different normalization requirements:
        /// for <see cref="math.logb(float)"/>, the normalized significand is in the interval <c>[1, 2)</c>,
        /// but for <see cref="math.frexp(float, ref int)"/>, the normalized significand is in the interval <c>[0.5, 1)</c>. 
        /// </para>
        /// </remarks>
        public static float logb(float number)
        {
            int exp = math.ilogb(number);
            switch (exp)
            {
                case math.FP_ILOGB0:
                    return System.Single.NegativeInfinity;
                case math.FP_ILOGBNAN:
                    return System.Single.NaN;
                case math.INT_MAX:
                    return System.Single.PositiveInfinity;
            }
            return exp;
        }

        #endregion

        #region "scalbn"

        /// <summary>
        /// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <param name="exponent">The exponent of the power of two.</param>
        /// <returns>The value <paramref name="number"/> time 2^<paramref name="exponent"/>.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="number"/> is <c>±0</c>, it is returned.
        /// If <paramref name="number"/> is infinite, it is returned.
        /// If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.
        /// </para>
        /// <para>
        /// The function <see cref="math.scalbn(double, int)"/> is equivalent to <see cref="math.ldexp(double, int)"/>.
        /// </para>
        /// </remarks>
        public static double scalbn(double number, int exponent)
        {
            return math.scalbln(number, exponent);
        }

        /// <summary>
        /// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <param name="exponent">The exponent of the power of two.</param>
        /// <returns>The value <paramref name="number"/> time 2^<paramref name="exponent"/>.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="number"/> is <c>±0</c>, it is returned.
        /// If <paramref name="number"/> is infinite, it is returned.
        /// If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="System.Single.NaN"/> is returned.
        /// </para>
        /// <para>
        /// The function <see cref="math.scalbn(float, int)"/> is equivalent to <see cref="math.ldexp(float, int)"/>.
        /// </para>
        /// </remarks>
        public static float scalbn(float number, int exponent)
        {
            return math.scalbln(number, exponent);
        }

        #endregion

        #region "scalbln"

        /// <summary>
        /// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <param name="exponent">The exponent of the power of two.</param>
        /// <returns>The value <paramref name="number"/> time 2^<paramref name="exponent"/>.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="number"/> is <c>±0</c>, it is returned.
        /// If <paramref name="number"/> is infinite, it is returned.
        /// If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.
        /// </para>
        /// <para>
        /// The function <see cref="math.scalbln(double, long)"/> is equivalent to <see cref="math.ldexp(double, int)"/>.
        /// </para>
        /// </remarks>
        public static double scalbln(double number, long exponent)
        {
            long bits = System.BitConverter.DoubleToInt64Bits(number);
            int exp = (int)((bits & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS);
            // Check for infinity or NaN.
            if (exp == 0x7ff)
                return number;
            // Check for 0 or subnormal.
            if (exp == 0)
            {
                // Check for 0.
                if ((bits & math.DBL_MANT_MASK) == 0)
                    return number;
                // Subnormal, scale number so that it is in [1, 2).
                number *= System.BitConverter.Int64BitsToDouble(0x4350000000000000L); // 2^54
                bits = System.BitConverter.DoubleToInt64Bits(number);
                exp = (int)((bits & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS) - 54;
            }
            // Check for underflow.
            if (exponent < -50000)
                return math.copysign(0D, number);
            // Check for overflow.
            if (exponent > 50000 || (long)exp + exponent > 0x7feL)
                return math.copysign(System.Double.PositiveInfinity, number);
            exp += (int)exponent;
            // Check for normal.
            if (exp > 0)
                return System.BitConverter.Int64BitsToDouble((bits & math.DBL_EXP_CLR_MASK) | ((long)exp << math.DBL_MANT_BITS));
            // Check for underflow.
            if (exp <= -54)
                return math.copysign(0D, number);
            // Subnormal.
            exp += 54;
            number = System.BitConverter.Int64BitsToDouble((bits & math.DBL_EXP_CLR_MASK) | ((long)exp << math.DBL_MANT_BITS));
            return number * System.BitConverter.Int64BitsToDouble(0x3c90000000000000L); // 2^-54
        }

        /// <summary>
        /// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <param name="exponent">The exponent of the power of two.</param>
        /// <returns>The value <paramref name="number"/> time 2^<paramref name="exponent"/>.</returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="number"/> is <c>±0</c>, it is returned.
        /// If <paramref name="number"/> is infinite, it is returned.
        /// If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.
        /// If <paramref name="number"/> is NaN, <see cref="System.Single.NaN"/> is returned.
        /// </para>
        /// <para>
        /// The function <see cref="math.scalbln(float, long)"/> is equivalent to <see cref="math.ldexp(float, int)"/>.
        /// </para>
        /// </remarks>
        public static float scalbln(float number, long exponent)
        {
            int bits = math.SingleToInt32Bits(number);
            int exp = (bits & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS;
            // Check for infinity or NaN.
            if (exp == 0xff)
                return number;
            // Check for 0 or subnormal.
            if (exp == 0)
            {
                // Check for 0.
                if ((bits & math.FLT_MANT_MASK) == 0)
                    return number;
                // Subnormal, scale number so that it is in [1, 2).
                number *= math.Int32BitsToSingle(0x4c000000); // 2^25
                bits = math.SingleToInt32Bits(number);
                exp = ((bits & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS) - 25;
            }
            // Check for underflow.
            if (exponent < -50000)
                return math.copysign(0F, number);
            // Check for overflow.
            if (exponent > 50000 || exp + exponent > 0xfe)
                return math.copysign(System.Single.PositiveInfinity, number);
            exp += (int)exponent;
            // Check for normal.
            if (exp > 0)
                return math.Int32BitsToSingle((bits & math.FLT_EXP_CLR_MASK) | (exp << math.FLT_MANT_BITS));
            // Check for underflow.
            if (exp <= -25)
                return math.copysign(0F, number);
            // Subnormal.
            exp += 25;
            number = math.Int32BitsToSingle((bits & math.FLT_EXP_CLR_MASK) | (exp << math.FLT_MANT_BITS));
            return number * math.Int32BitsToSingle(0x33000000); // 2^-25
        }

        #endregion

        #endregion

        #region "Floating-point manipulation functions."

        #region "copysign"

        /// <summary>
        /// Copies the sign of <paramref name="number2"/> to <paramref name="number1"/>.
        /// </summary>
        /// <param name="number1">A floating-point number.</param>
        /// <param name="number2">A floating-point number.</param>
        /// <returns>The floating-point number whose absolute value is that of <paramref name="number1"/> with the sign of <paramref name="number2"/>.</returns>
        /// <remarks>
        /// <para>
        /// <see cref="math.copysign(double, double)"/> is the only portable way to manipulate the sign of a <see cref="System.Double.NaN"/> value (to examine
        /// the sign of a <see cref="System.Double.NaN"/>, <see cref="math.signbit(double)"/> may also be used). 
        /// </para>
        /// </remarks>
        public static double copysign(double number1, double number2)
        {
            // If number1 is NaN, we have to store in it the opposite of the sign bit.
            long sign = (math.signbit(number2) == 1 ? math.DBL_SGN_MASK : 0L) ^ (System.Double.IsNaN(number1) ? math.DBL_SGN_MASK : 0L);
            return System.BitConverter.Int64BitsToDouble((System.BitConverter.DoubleToInt64Bits(number1) & math.DBL_SGN_CLR_MASK) | sign);
        }

        /// <summary>
        /// Copies the sign of <paramref name="number2"/> to <paramref name="number1"/>.
        /// </summary>
        /// <param name="number1">A floating-point number.</param>
        /// <param name="number2">A floating-point number.</param>
        /// <returns>The floating-point number whose absolute value is that of <paramref name="number1"/> with the sign of <paramref name="number2"/>.</returns>
        /// <remarks>
        /// <para>
        /// <see cref="math.copysign(float, float)"/> is the only portable way to manipulate the sign of a <see cref="System.Single.NaN"/> value (to examine
        /// the sign of a <see cref="System.Single.NaN"/>, <see cref="math.signbit(float)"/> may also be used). 
        /// </para>
        /// </remarks>
        public static float copysign(float number1, float number2)
        {
            // If number1 is NaN, we have to store in it the opposite of the sign bit.
            int sign = (math.signbit(number2) == 1 ? math.FLT_SGN_MASK : 0) ^ (System.Double.IsNaN(number1) ? math.FLT_SGN_MASK : 0);
            return math.Int32BitsToSingle((math.SingleToInt32Bits(number1) & math.FLT_SGN_CLR_MASK) | sign);
        }

        #endregion

        #region "nextafter"

        /// <summary>
        /// Gets the floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.
        /// </summary>
        /// <param name="fromNumber">A floating-point number.</param>
        /// <param name="towardNumber">A floating-point number.</param>
        /// <returns>The floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.</returns>
        /// <remarks>
        /// <para>
        /// IEC 60559 recommends that <paramref name="fromNumber"/> be returned whenever <c><paramref name="fromNumber"/> == <paramref name="towardNumber"/></c>.
        /// These functions return <paramref name="towardNumber"/> instead, which makes the behavior around zero consistent: <c><see cref="math.nextafter"/>(-0.0, +0.0)</c>
        /// returns <c>+0.0</c> and <c><see cref="math.nextafter"/>(+0.0, -0.0)</c> returns <c>–0.0</c>.
        /// </para>
        /// </remarks>
        public static double nextafter(double fromNumber, double towardNumber)
        {
            // If either fromNumber or towardNumber is NaN, return NaN.
            if (System.Double.IsNaN(towardNumber) || System.Double.IsNaN(fromNumber))
            {
                return System.Double.NaN;
            }
            // If no direction.
            if (fromNumber == towardNumber)
            {
                return towardNumber;
            }
            // If fromNumber is zero, return smallest subnormal.
            if (fromNumber == 0)
            {
                return (towardNumber > 0) ? System.Double.Epsilon : -System.Double.Epsilon;
            }
            // All other cases are handled by incrementing or decrementing the bits value.
            // Transitions to infinity, to subnormal, and to zero are all taken care of this way.
            long bits = System.BitConverter.DoubleToInt64Bits(fromNumber);
            // A xor here avoids nesting conditionals. We have to increment if fromValue lies between 0 and toValue.
            if ((fromNumber > 0) ^ (fromNumber > towardNumber))
            {
                bits += 1;
            }
            else
            {
                bits -= 1;
            }
            return System.BitConverter.Int64BitsToDouble(bits);
        }

        /// <summary>
        /// Gets the floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.
        /// </summary>
        /// <param name="fromNumber">A floating-point number.</param>
        /// <param name="towardNumber">A floating-point number.</param>
        /// <returns>The floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.</returns>
        /// <remarks>
        /// <para>
        /// IEC 60559 recommends that <paramref name="fromNumber"/> be returned whenever <c><paramref name="fromNumber"/> == <paramref name="towardNumber"/></c>.
        /// These functions return <paramref name="towardNumber"/> instead, which makes the behavior around zero consistent: <c><see cref="math.nextafter"/>(-0.0, +0.0)</c>
        /// returns <c>+0.0</c> and <c><see cref="math.nextafter"/>(+0.0, -0.0)</c> returns <c>–0.0</c>.
        /// </para>
        /// </remarks>
        public static float nextafter(float fromNumber, float towardNumber)
        {
            // If either fromNumber or towardNumber is NaN, return NaN.
            if (System.Single.IsNaN(towardNumber) || System.Single.IsNaN(fromNumber))
            {
                return System.Single.NaN;
            }
            // If no direction or if fromNumber is infinity or is not a number, return fromNumber.
            if (fromNumber == towardNumber)
            {
                return towardNumber;
            }
            // If fromNumber is zero, return smallest subnormal.
            if (fromNumber == 0)
            {
                return (towardNumber > 0) ? System.Single.Epsilon : -System.Single.Epsilon;
            }
            // All other cases are handled by incrementing or decrementing the bits value.
            // Transitions to infinity, to subnormal, and to zero are all taken care of this way.
            int bits = SingleToInt32Bits(fromNumber);
            // A xor here avoids nesting conditionals. We have to increment if fromValue lies between 0 and toValue.
            if ((fromNumber > 0) ^ (fromNumber > towardNumber))
            {
                bits += 1;
            }
            else
            {
                bits -= 1;
            }
            return Int32BitsToSingle(bits);
        }

        #endregion

        #region "nexttoward"

        /// <summary>
        /// Gets the floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.
        /// </summary>
        /// <param name="fromNumber">A floating-point number.</param>
        /// <param name="towardNumber">A floating-point number.</param>
        /// <returns>The floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.</returns>
        /// <remarks>
        /// <para>
        /// IEC 60559 recommends that <paramref name="fromNumber"/> be returned whenever <c><paramref name="fromNumber"/> == <paramref name="towardNumber"/></c>.
        /// These functions return <paramref name="towardNumber"/> instead, which makes the behavior around zero consistent: <c><see cref="math.nexttoward"/>(-0.0, +0.0)</c>
        /// returns <c>+0.0</c> and <c><see cref="math.nexttoward"/>(+0.0, -0.0)</c> returns <c>–0.0</c>.
        /// </para>
        /// <para>
        /// The <see cref="math.nexttoward"/> function is equivalent to the <see cref="math.nextafter"/> function.
        /// </para>
        /// </remarks>
        public static double nexttoward(double fromNumber, double towardNumber)
        {
            return math.nextafter(fromNumber, towardNumber);
        }

        /// <summary>
        /// Gets the floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.
        /// </summary>
        /// <param name="fromNumber">A floating-point number.</param>
        /// <param name="towardNumber">A floating-point number.</param>
        /// <returns>The floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.</returns>
        /// <remarks>
        /// <para>
        /// IEC 60559 recommends that <paramref name="fromNumber"/> be returned whenever <c><paramref name="fromNumber"/> == <paramref name="towardNumber"/></c>.
        /// These functions return <paramref name="towardNumber"/> instead, which makes the behavior around zero consistent: <c><see cref="math.nexttoward"/>(-0.0, +0.0)</c>
        /// returns <c>+0.0</c> and <c><see cref="math.nexttoward"/>(+0.0, -0.0)</c> returns <c>–0.0</c>.
        /// </para>
        /// <para>
        /// The <see cref="math.nexttoward"/> function is equivalent to the <see cref="math.nextafter"/> function.
        /// </para>
        /// </remarks>
        public static float nexttoward(float fromNumber, float towardNumber)
        {
            return math.nextafter(fromNumber, towardNumber);
        }

        #endregion

        #region "exponent"

        /// <summary>
        /// Gets the exponent bits of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The exponent bits of the specified floating-point <paramref name="number"/>.</returns>
        /// <remarks>
        /// <list type="table">
        ///     <listheader>
        ///        <term><paramref name="number"/></term> 
        ///        <description>Exponent</description> 
        ///     </listheader>
        ///     <item>
        ///         <term><c>±<see cref="System.Double.NaN"/></c></term>
        ///         <description><c>2047</c> (<c><see cref="math.DBL_EXP_MAX"/> + 1 + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="System.Double.PositiveInfinity"/></c></term>
        ///         <description><c>2047</c> (<c><see cref="math.DBL_EXP_MAX"/> + 1 + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="System.Double.NegativeInfinity"/></c></term>
        ///         <description><c>2047</c> (<c><see cref="math.DBL_EXP_MAX"/> + 1 + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c>±<see cref="IEEE754Double.MaxNormal"/></c></term>
        ///         <description><c>2046</c> (<c><see cref="math.DBL_EXP_MAX"/> + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c>±<see cref="IEEE754Double.MinNormal"/></c></term>
        ///         <description><c>1</c> (<c><see cref="math.DBL_EXP_MIN"/> + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c>±<see cref="math.DBL_DENORM_MAX"/></c></term>
        ///         <description><c>0</c></description>
        ///     </item>
        ///     <item>
        ///         <term><c>±<see cref="math.DBL_DENORM_MIN"/></c></term>
        ///         <description><c>0</c></description>
        ///     </item>
        ///     <item>
        ///         <term><c>±0</c></term>
        ///         <description><c>0</c></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public static int exponent(double number)
        {
            return System.Convert.ToInt32((System.BitConverter.DoubleToInt64Bits(number) & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS);
        }

        /// <summary>
        /// Gets the exponent bits of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The exponent bits of the specified floating-point <paramref name="number"/>.</returns>
        /// <remarks>
        /// <list type="table">
        ///     <listheader>
        ///        <term><paramref name="number"/></term> 
        ///        <description>Exponent</description> 
        ///     </listheader>
        ///     <item>
        ///         <term><c>±<see cref="System.Single.NaN"/></c></term>
        ///         <description><c>255</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1 + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="System.Single.PositiveInfinity"/></c></term>
        ///         <description><c>255</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1 + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c><see cref="System.Single.NegativeInfinity"/></c></term>
        ///         <description><c>255</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1 + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c>±<see cref="IEEE754Single.MaxNormal"/></c></term>
        ///         <description><c>254</c> (<c><see cref="math.FLT_EXP_MAX"/> + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c>±<see cref="IEEE754Single.MinNormal"/></c></term>
        ///         <description><c>1</c> (<c><see cref="math.FLT_EXP_MIN"/> + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
        ///     </item>
        ///     <item>
        ///         <term><c>±<see cref="math.FLT_DENORM_MAX"/></c></term>
        ///         <description><c>0</c></description>
        ///     </item>
        ///     <item>
        ///         <term><c>±<see cref="math.FLT_DENORM_MIN"/></c></term>
        ///         <description><c>0</c></description>
        ///     </item>
        ///     <item>
        ///         <term><c>±0</c></term>
        ///         <description><c>0</c></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public static int exponent(float number)
        {
            return System.Convert.ToInt32((math.SingleToInt32Bits(number) & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS);
        }

        #endregion

        #region "mantissa"

        /// <summary>
        /// Gets the mantissa bits of the specified floating-point <paramref name="number"/> without the implicit leading <c>1</c> bit.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The mantissa bits of the specified floating-point <paramref name="number"/> without the implicit leading <c>1</c> bit.</returns>
        /// <remarks></remarks>
        public static long mantissa(double number)
        {
            return System.BitConverter.DoubleToInt64Bits(number) & math.DBL_MANT_MASK;
        }

        /// <summary>
        /// Gets the mantissa bits of the specified floating-point <paramref name="number"/> without the implicit leading <c>1</c> bit.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The mantissa bits of the specified floating-point <paramref name="number"/> without the implicit leading <c>1</c> bit.</returns>
        /// <remarks></remarks>
        public static int mantissa(float number)
        {
            return math.SingleToInt32Bits(number) & math.FLT_MANT_MASK;
        }

        #endregion

        #region "significand"

        /// <summary>
        /// Gets the significand of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The significand of the specified floating-point <paramref name="number"/>, or <paramref name="number"/> if it not normal or subnormal.</returns>
        /// <remarks>
        /// <para>
        /// The significand is a number in the interval <c>[1, 2)</c> so that 
        /// <c><paramref name="number"/> = <see cref="math.significand(double)"/>(<paramref name="number"/>) * 2^<see cref="math.logb(double)"/>(<paramref name="number"/>)</c>.
        /// If <paramref name="number"/> is subnormal, it is normalized so that the significand falls in the interval <c>[1, 2)</c>.
        /// </para>
        /// </remarks>
        public static double significand(double number)
        {
            // If not-a-numbner or infinity, simply return number.
            if (System.Double.IsNaN(number) || System.Double.IsInfinity(number))
                return number;
            // Get the mantissa bits.
            long mantissa = math.mantissa(number);
            // If the unbiased exponent is 0, we have either 0 or a subnormal number.
            if (math.exponent(number) == 0)
            {
                // If number is zero, return zero.
                if (mantissa == 0L)
                    return number;
                // Otherwise, shift the mantissa to the left until its first 1-bit makes
                // the mantissa larger than or equal to the mantissa mask, and reset the
                // the leading 1 bit. This yields a "normalized" number.
                while (mantissa < math.DBL_MANT_MASK)
                {
                    mantissa <<= 1;
                }
                mantissa = mantissa & math.DBL_MANT_MASK;
            }
            // Build new double with exponent 0 and the normalized mantissa.
            return System.BitConverter.Int64BitsToDouble((System.Convert.ToInt64(math.DBL_EXP_BIAS) << math.DBL_MANT_BITS) | mantissa | (math.signbit(number) == 1 ? math.DBL_SGN_MASK : 0L));
        }

        /// <summary>
        /// Gets the significand of the specified floating-point <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A floating-point number.</param>
        /// <returns>The significand of the specified floating-point <paramref name="number"/>, or <paramref name="number"/> if it not normal or subnormal.</returns>
        /// <remarks>
        /// <para>
        /// The significand is a number in the interval <c>[1, 2)</c> so that 
        /// <c><paramref name="number"/> = <see cref="math.significand(float)"/>(<paramref name="number"/>) * 2^<see cref="math.logb(float)"/>(<paramref name="number"/>)</c>.
        /// If <paramref name="number"/> is subnormal, it is normalized so that the significand falls in the interval <c>[1, 2)</c>.
        /// </para>
        /// </remarks>
        public static float significand(float number)
        {
            // If not-a-numbner or infinity, simply return number.
            if (System.Single.IsNaN(number) || System.Single.IsInfinity(number))
                return number;
            // Get the mantissa bits.
            int mantissa = math.mantissa(number);
            // If the unbiased exponent is 0, we have either 0 or a subnormal number.
            if (math.exponent(number) == 0)
            {
                // If number is zero, return zero.
                if (mantissa == 0F)
                    return number;
                // Otherwise, shift the mantissa to the left until its first 1-bit makes
                // the mantissa larger than or equal to the mantissa mask, and reset the
                // the leading 1 bit. This yields a "normalized" number.
                while (mantissa < math.FLT_MANT_MASK)
                {
                    mantissa <<= 1;
                }
                mantissa = mantissa & math.FLT_MANT_MASK;
            }
            // Build new float with exponent 0 and the normalized mantissa.
            return math.Int32BitsToSingle((System.Convert.ToInt32(math.FLT_EXP_BIAS) << math.FLT_MANT_BITS) | mantissa | (math.signbit(number) == 1 ? math.FLT_SGN_MASK : 0));
        }

        #endregion

        #endregion

        #region "Comparison functions."

        #region "isunordered"

        /// <summary>
        /// Gets a value that indicates whether two floating-point numbers are unordered.
        /// </summary>
        /// <param name="number1">A floating-point number.</param>
        /// <param name="number2">A floating-point number.</param>
        /// <returns><c>true</c> if either <paramref name="number1"/> or <paramref name="number1"/> is <see cref="System.Double.NaN"/>, <c>false</c> otherwise.</returns>
        /// <remarks></remarks>
        public static bool isunordered(double number1, double number2)
        {
            return System.Double.IsNaN(number1) || System.Double.IsNaN(number2);
        }

        /// <summary>
        /// Gets a value that indicates whether two floating-point numbers are unordered.
        /// </summary>
        /// <param name="number1">A floating-point number.</param>
        /// <param name="number2">A floating-point number.</param>
        /// <returns><c>true</c> if either <paramref name="number1"/> or <paramref name="number1"/> is <see cref="System.Single.NaN"/>, <c>false</c> otherwise.</returns>
        /// <remarks></remarks>
        public static bool isunordered(float number1, float number2)
        {
            return System.Single.IsNaN(number1) || System.Single.IsNaN(number2);
        }

        #endregion

        #endregion

        #region "Miscellaneous functions."

        /// <summary>
        /// Converts the specified single-precision floating point number to a 32-bit signed integer.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A 32-bit signed integer whose value is equivalent to <paramref name="value"/>.</returns>
        public static unsafe int SingleToInt32Bits(float value)
        {
            return *((int*)&value);
        }

        /// <summary>
        /// Converts the specified 32-bit signed integer to a single-precision floating point number.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A double-precision floating point number whose value is equivalent to <paramref name="value"/>.</returns>
        public static unsafe float Int32BitsToSingle(int value)
        {
            return *((float*)&value);
        }

        private static int _leadingZeroesCount(int x)
        {
            int y;
            int n = 32;
            y = x >> 16; if (y != 0) { n = n - 16; x = y; }
            y = x >> 8; if (y != 0) { n = n - 8; x = y; }
            y = x >> 4; if (y != 0) { n = n - 4; x = y; }
            y = x >> 2; if (y != 0) { n = n - 2; x = y; }
            y = x >> 1; if (y != 0) return n - 2;
            return n - x;
        }

        private static int _leadingZeroesCount(long x)
        {
            long y;
            int n = 64;
            y = x >> 32; if (y != 0) { n = n - 32; x = y; }
            y = x >> 16; if (y != 0) { n = n - 16; x = y; }
            y = x >> 8; if (y != 0) { n = n - 8; x = y; }
            y = x >> 4; if (y != 0) { n = n - 4; x = y; }
            y = x >> 2; if (y != 0) { n = n - 2; x = y; }
            y = x >> 1; if (y != 0) return n - 2;
            return n - (int)x;
        }

        #endregion
    }
}
