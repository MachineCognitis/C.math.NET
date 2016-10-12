
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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C
{
    [TestClass]
    public class IEEE754Tests
    {

        [TestMethod]
        public void fpclassify()
        {

            Assert.IsTrue(math.fpclassify(System.Double.NaN) == math.FP_NAN);
            Assert.IsTrue(math.fpclassify(System.Double.PositiveInfinity) == math.FP_INFINITE);
            Assert.IsTrue(math.fpclassify(+0D) == math.FP_ZERO);
            Assert.IsTrue(math.fpclassify(+1000D) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(+math.DBL_MAX) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(+math.DBL_MIN) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(+math.DBL_DENORM_MAX) == math.FP_SUBNORMAL);
            Assert.IsTrue(math.fpclassify(+math.DBL_DENORM_MIN) == math.FP_SUBNORMAL);

            Assert.IsTrue(math.fpclassify(-System.Double.NaN) == math.FP_NAN);
            Assert.IsTrue(math.fpclassify(System.Double.NegativeInfinity) == math.FP_INFINITE);
            Assert.IsTrue(math.fpclassify(-0D) == math.FP_ZERO);
            Assert.IsTrue(math.fpclassify(-1000D) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(-math.DBL_MAX) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(-math.DBL_MIN) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(-math.DBL_DENORM_MAX) == math.FP_SUBNORMAL);
            Assert.IsTrue(math.fpclassify(-math.DBL_DENORM_MIN) == math.FP_SUBNORMAL);

            Assert.IsTrue(math.fpclassify(System.Single.NaN) == math.FP_NAN);
            Assert.IsTrue(math.fpclassify(System.Single.PositiveInfinity) == math.FP_INFINITE);
            Assert.IsTrue(math.fpclassify(+0F) == math.FP_ZERO);
            Assert.IsTrue(math.fpclassify(+1000F) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(+math.FLT_MAX) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(+math.FLT_MIN) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(+math.FLT_DENORM_MAX) == math.FP_SUBNORMAL);
            Assert.IsTrue(math.fpclassify(+math.FLT_DENORM_MIN) == math.FP_SUBNORMAL);

            Assert.IsTrue(math.fpclassify(-System.Single.NaN) == math.FP_NAN);
            Assert.IsTrue(math.fpclassify(System.Single.NegativeInfinity) == math.FP_INFINITE);
            Assert.IsTrue(math.fpclassify(-0F) == math.FP_ZERO);
            Assert.IsTrue(math.fpclassify(-1000F) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(-math.FLT_MAX) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(-math.FLT_MIN) == math.FP_NORMAL);
            Assert.IsTrue(math.fpclassify(-math.FLT_DENORM_MAX) == math.FP_SUBNORMAL);
            Assert.IsTrue(math.fpclassify(-math.FLT_DENORM_MIN) == math.FP_SUBNORMAL);

        }

        [TestMethod]
        public void isfinite()
        {
            Assert.IsTrue(math.isfinite(0D));
            Assert.IsTrue(math.isfinite(-0D));
            Assert.IsTrue(math.isfinite(10D));
            Assert.IsTrue(math.isfinite(math.DBL_DENORM_MIN));
            Assert.IsTrue(math.isfinite(-math.DBL_DENORM_MIN));
            Assert.IsTrue(math.isfinite(math.DBL_DENORM_MAX));
            Assert.IsTrue(math.isfinite(-math.DBL_DENORM_MAX));
            Assert.IsTrue(math.isfinite(math.DBL_MIN));
            Assert.IsTrue(math.isfinite(-math.DBL_MIN));
            Assert.IsTrue(math.isfinite(math.DBL_MAX));
            Assert.IsTrue(math.isfinite(-math.DBL_MAX));
            Assert.IsTrue(math.isfinite(System.Double.MinValue));
            Assert.IsTrue(math.isfinite(-System.Double.MinValue));
            Assert.IsTrue(math.isfinite(System.Double.MaxValue));
            Assert.IsTrue(math.isfinite(-System.Double.MaxValue));
            Assert.IsFalse(math.isfinite(System.Double.PositiveInfinity));
            Assert.IsFalse(math.isfinite(System.Double.NegativeInfinity));
            Assert.IsFalse(math.isfinite(System.Double.NaN));
            Assert.IsFalse(math.isfinite(-System.Double.NaN));

            Assert.IsTrue(math.isfinite(0F));
            Assert.IsTrue(math.isfinite(-0F));
            Assert.IsTrue(math.isfinite(10F));
            Assert.IsTrue(math.isfinite(math.FLT_DENORM_MIN));
            Assert.IsTrue(math.isfinite(-math.FLT_DENORM_MIN));
            Assert.IsTrue(math.isfinite(math.FLT_DENORM_MAX));
            Assert.IsTrue(math.isfinite(-math.FLT_DENORM_MAX));
            Assert.IsTrue(math.isfinite(math.FLT_MIN));
            Assert.IsTrue(math.isfinite(-math.FLT_MIN));
            Assert.IsTrue(math.isfinite(math.FLT_MAX));
            Assert.IsTrue(math.isfinite(-math.FLT_MAX));
            Assert.IsTrue(math.isfinite(System.Single.MinValue));
            Assert.IsTrue(math.isfinite(-System.Single.MinValue));
            Assert.IsTrue(math.isfinite(System.Single.MaxValue));
            Assert.IsTrue(math.isfinite(-System.Single.MaxValue));
            Assert.IsFalse(math.isfinite(System.Single.PositiveInfinity));
            Assert.IsFalse(math.isfinite(System.Single.NegativeInfinity));
            Assert.IsFalse(math.isfinite(System.Single.NaN));
            Assert.IsFalse(math.isfinite(-System.Single.NaN));
        }

        [TestMethod]
        public void isinf()
        {
            Assert.IsFalse(math.isinf(0D));
            Assert.IsFalse(math.isinf(-0D));
            Assert.IsFalse(math.isinf(10D));
            Assert.IsFalse(math.isinf(-10D));
            Assert.IsFalse(math.isinf(math.DBL_DENORM_MIN));
            Assert.IsFalse(math.isinf(-math.DBL_DENORM_MIN));
            Assert.IsFalse(math.isinf(math.DBL_DENORM_MAX));
            Assert.IsFalse(math.isinf(-math.DBL_DENORM_MAX));
            Assert.IsFalse(math.isinf(math.DBL_MIN));
            Assert.IsFalse(math.isinf(-math.DBL_MIN));
            Assert.IsFalse(math.isinf(math.DBL_MAX));
            Assert.IsFalse(math.isinf(-math.DBL_MAX));
            Assert.IsTrue(math.isinf(System.Double.PositiveInfinity));
            Assert.IsTrue(math.isinf(System.Double.NegativeInfinity));
            Assert.IsFalse(math.isinf(System.Double.NaN));
            Assert.IsFalse(math.isinf(-System.Double.NaN));

            Assert.IsFalse(math.isinf(0F));
            Assert.IsFalse(math.isinf(-0F));
            Assert.IsFalse(math.isinf(10F));
            Assert.IsFalse(math.isinf(-10F));
            Assert.IsFalse(math.isinf(math.FLT_DENORM_MIN));
            Assert.IsFalse(math.isinf(-math.FLT_DENORM_MIN));
            Assert.IsFalse(math.isinf(math.FLT_DENORM_MAX));
            Assert.IsFalse(math.isinf(-math.FLT_DENORM_MAX));
            Assert.IsFalse(math.isinf(math.FLT_MIN));
            Assert.IsFalse(math.isinf(-math.FLT_MIN));
            Assert.IsFalse(math.isinf(math.FLT_MAX));
            Assert.IsFalse(math.isinf(-math.FLT_MAX));
            Assert.IsTrue(math.isinf(System.Single.PositiveInfinity));
            Assert.IsTrue(math.isinf(System.Single.NegativeInfinity));
            Assert.IsFalse(math.isinf(System.Single.NaN));
            Assert.IsFalse(math.isinf(-System.Single.NaN));
        }

        [TestMethod]
        public void isnan()
        {
            Assert.IsFalse(math.isnan(0D));
            Assert.IsFalse(math.isnan(-0D));
            Assert.IsFalse(math.isnan(10D));
            Assert.IsFalse(math.isnan(-10D));
            Assert.IsFalse(math.isnan(math.DBL_DENORM_MIN));
            Assert.IsFalse(math.isnan(-math.DBL_DENORM_MIN));
            Assert.IsFalse(math.isnan(math.DBL_DENORM_MAX));
            Assert.IsFalse(math.isnan(-math.DBL_DENORM_MAX));
            Assert.IsFalse(math.isnan(math.DBL_MIN));
            Assert.IsFalse(math.isnan(-math.DBL_MIN));
            Assert.IsFalse(math.isnan(math.DBL_MAX));
            Assert.IsFalse(math.isnan(-math.DBL_MAX));
            Assert.IsFalse(math.isnan(System.Double.PositiveInfinity));
            Assert.IsFalse(math.isnan(System.Double.NegativeInfinity));
            Assert.IsTrue(math.isnan(System.Double.NaN));
            Assert.IsTrue(math.isnan(-System.Double.NaN));

            Assert.IsFalse(math.isnan(0F));
            Assert.IsFalse(math.isnan(-0F));
            Assert.IsFalse(math.isnan(10F));
            Assert.IsFalse(math.isnan(-10F));
            Assert.IsFalse(math.isnan(math.FLT_DENORM_MIN));
            Assert.IsFalse(math.isnan(-math.FLT_DENORM_MIN));
            Assert.IsFalse(math.isnan(math.FLT_DENORM_MAX));
            Assert.IsFalse(math.isnan(-math.FLT_DENORM_MAX));
            Assert.IsFalse(math.isnan(math.FLT_MIN));
            Assert.IsFalse(math.isnan(-math.FLT_MIN));
            Assert.IsFalse(math.isnan(math.FLT_MAX));
            Assert.IsFalse(math.isnan(-math.FLT_MAX));
            Assert.IsFalse(math.isnan(System.Single.PositiveInfinity));
            Assert.IsFalse(math.isnan(System.Single.NegativeInfinity));
            Assert.IsTrue(math.isnan(System.Single.NaN));
            Assert.IsTrue(math.isnan(-System.Single.NaN));
        }

        [TestMethod]
        public void isnormal()
        {
            Assert.IsFalse(math.isnormal(0D));
            Assert.IsFalse(math.isnormal(-0D));
            Assert.IsTrue(math.isnormal(10D));
            Assert.IsTrue(math.isnormal(-10D));
            Assert.IsFalse(math.isnormal(math.DBL_DENORM_MIN));
            Assert.IsFalse(math.isnormal(-math.DBL_DENORM_MIN));
            Assert.IsFalse(math.isnormal(math.DBL_DENORM_MAX));
            Assert.IsFalse(math.isnormal(-math.DBL_DENORM_MAX));
            Assert.IsTrue(math.isnormal(math.DBL_MIN));
            Assert.IsTrue(math.isnormal(-math.DBL_MIN));
            Assert.IsTrue(math.isnormal(math.DBL_MAX));
            Assert.IsTrue(math.isnormal(-math.DBL_MAX));
            Assert.IsFalse(math.isnormal(System.Double.PositiveInfinity));
            Assert.IsFalse(math.isnormal(System.Double.NegativeInfinity));
            Assert.IsFalse(math.isnormal(System.Double.NaN));
            Assert.IsFalse(math.isnormal(-System.Double.NaN));

            Assert.IsFalse(math.isnormal(0F));
            Assert.IsFalse(math.isnormal(-0F));
            Assert.IsTrue(math.isnormal(10F));
            Assert.IsTrue(math.isnormal(-10F));
            Assert.IsFalse(math.isnormal(math.FLT_DENORM_MIN));
            Assert.IsFalse(math.isnormal(-math.FLT_DENORM_MIN));
            Assert.IsFalse(math.isnormal(math.FLT_DENORM_MAX));
            Assert.IsFalse(math.isnormal(-math.FLT_DENORM_MAX));
            Assert.IsTrue(math.isnormal(math.FLT_MIN));
            Assert.IsTrue(math.isnormal(-math.FLT_MIN));
            Assert.IsTrue(math.isnormal(math.FLT_MAX));
            Assert.IsTrue(math.isnormal(-math.FLT_MAX));
            Assert.IsFalse(math.isnormal(System.Single.PositiveInfinity));
            Assert.IsFalse(math.isnormal(System.Single.NegativeInfinity));
            Assert.IsFalse(math.isnormal(System.Single.NaN));
            Assert.IsFalse(math.isnormal(-System.Single.NaN));
        }

        [TestMethod]
        public void signbit()
        {
            Assert.IsTrue(math.signbit(0D) == 0);
            Assert.IsTrue(math.signbit(-0D) == 1);
            Assert.IsTrue(math.signbit(System.Double.PositiveInfinity) == 0);
            Assert.IsTrue(math.signbit(System.Double.NegativeInfinity) == 1);
            Assert.IsTrue(math.signbit(System.Double.NaN) == 0);
            Assert.IsTrue(math.signbit(-System.Double.NaN) == 1);

            Assert.IsTrue(math.signbit(-1D) == 1);
            Assert.IsTrue(math.signbit(-math.DBL_MIN) == 1);
            Assert.IsTrue(math.signbit(-math.DBL_DENORM_MAX) == 1);
            Assert.IsTrue(math.signbit(-math.DBL_MAX) == 1);

            Assert.IsTrue(math.signbit(1D) == 0);
            Assert.IsTrue(math.signbit(math.DBL_MIN) == 0);
            Assert.IsTrue(math.signbit(math.DBL_DENORM_MAX) == 0);
            Assert.IsTrue(math.signbit(math.DBL_MAX) == 0);


            Assert.IsTrue(math.signbit(0F) == 0);
            Assert.IsTrue(math.signbit(-0F) == 1);
            Assert.IsTrue(math.signbit(System.Single.PositiveInfinity) == 0);
            Assert.IsTrue(math.signbit(System.Single.NegativeInfinity) == 1);
            Assert.IsTrue(math.signbit(System.Single.NaN) == 0);
            Assert.IsTrue(math.signbit(-System.Single.NaN) == 1);

            Assert.IsTrue(math.signbit(-1F) == 1);
            Assert.IsTrue(math.signbit(-math.FLT_MIN) == 1);
            Assert.IsTrue(math.signbit(-math.FLT_DENORM_MAX) == 1);
            Assert.IsTrue(math.signbit(-math.FLT_MAX) == 1);

            Assert.IsTrue(math.signbit(1F) == 0);
            Assert.IsTrue(math.signbit(math.FLT_MIN) == 0);
            Assert.IsTrue(math.signbit(math.FLT_DENORM_MAX) == 0);
            Assert.IsTrue(math.signbit(math.FLT_MAX) == 0);
        }

        [TestMethod]
        public void frexp()
        {
            int exponent = 0;

            Assert.IsTrue(math.frexp(System.Double.PositiveInfinity, ref exponent) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.frexp(System.Double.NegativeInfinity, ref exponent) == System.Double.NegativeInfinity);
            Assert.IsTrue(System.Double.IsNaN(math.frexp(System.Double.NaN, ref exponent)));
            Assert.IsTrue(System.Double.IsNaN(math.frexp(-System.Double.NaN, ref exponent)));

            Assert.IsTrue(math.frexp(0D, ref exponent) == 0D);
            Assert.IsTrue(exponent == 0);
            Assert.IsTrue(math.frexp(-0D, ref exponent) == -0D);
            Assert.IsTrue(math.signbit(math.frexp(-0D, ref exponent)) == 1);
            Assert.IsTrue(exponent == 0);
            Assert.IsTrue(math.frexp(12.8D, ref exponent) == 0.8D);
            Assert.IsTrue(exponent == 4);
            Assert.IsTrue(math.frexp(-27.34D, ref exponent) == -0.854375D);
            Assert.IsTrue(exponent == 5);
            Assert.IsTrue(math.frexp(0.25D, ref exponent) == 0.5D);
            Assert.IsTrue(exponent == -1);
            Assert.IsTrue(math.frexp(0.5D, ref exponent) == 0.5D);
            Assert.IsTrue(exponent == 0);
            Assert.IsTrue(math.frexp(1D, ref exponent) == 0.5D);
            Assert.IsTrue(exponent == 1);
            Assert.IsTrue(math.frexp(-1D, ref exponent) == -0.5D);
            Assert.IsTrue(exponent == 1);
            Assert.IsTrue(math.frexp(2D, ref exponent) == 0.5D);
            Assert.IsTrue(exponent == 2);
            Assert.IsTrue(math.frexp(4D, ref exponent) == 0.5D);
            Assert.IsTrue(exponent == 3);

            Assert.IsTrue(math.frexp(System.Math.Pow(2D, 127D), ref exponent) == 0.5D);
            Assert.IsTrue(exponent == 128);
            Assert.IsTrue(math.frexp(-System.Math.Pow(2D, 127D), ref exponent) == -0.5D);
            Assert.IsTrue(exponent == 128);
            Assert.IsTrue(math.frexp(System.Math.Pow(2D, -126D), ref exponent) == 0.5D);
            Assert.IsTrue(exponent == -125);
            Assert.IsTrue(math.frexp(System.Math.Pow(2D, -127D), ref exponent) == 0.5D);
            Assert.IsTrue(exponent == -126);
            Assert.IsTrue(math.frexp(System.Math.Pow(2D, -149D), ref exponent) == 0.5D);
            Assert.IsTrue(exponent == -148);
            Assert.IsTrue(math.frexp(-System.Math.Pow(2D, -149D), ref exponent) == -0.5D);
            Assert.IsTrue(exponent == -148);

            Assert.IsTrue(math.frexp(System.Math.Pow(2D, 1023), ref exponent) == 0.5D);
            Assert.IsTrue(exponent == 1024);
            Assert.IsTrue(math.frexp(-System.Math.Pow(2D, 1023), ref exponent) == -0.5D);
            Assert.IsTrue(exponent == 1024);
            Assert.IsTrue(math.frexp(System.Math.Pow(2D, -1022), ref exponent) == 0.5D);
            Assert.IsTrue(exponent == -1021);
            Assert.IsTrue(math.frexp(System.Math.Pow(2D, -1023), ref exponent) == 0.5D);
            Assert.IsTrue(exponent == -1022);
            Assert.IsTrue(math.frexp(System.Math.Pow(2D, -1074), ref exponent) == 0.5D);
            Assert.IsTrue(exponent == -1073);
            Assert.IsTrue(math.frexp(-System.Math.Pow(2D, -1074), ref exponent) == -0.5D);
            Assert.IsTrue(exponent == -1073);


            Assert.IsTrue(math.frexp(System.Single.PositiveInfinity, ref exponent) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.frexp(System.Single.NegativeInfinity, ref exponent) == System.Single.NegativeInfinity);
            Assert.IsTrue(System.Double.IsNaN(math.frexp(System.Single.NaN, ref exponent)));
            Assert.IsTrue(System.Double.IsNaN(math.frexp(-System.Single.NaN, ref exponent)));

            Assert.IsTrue(math.frexp(0F, ref exponent) == 0F);
            Assert.IsTrue(exponent == 0);
            Assert.IsTrue(math.frexp(-0F, ref exponent) == -0F);
            Assert.IsTrue(math.signbit(math.frexp(-0F, ref exponent)) == 1);
            Assert.IsTrue(exponent == 0);
            Assert.IsTrue(math.frexp(12.8F, ref exponent) == 0.8F);
            Assert.IsTrue(exponent == 4);
            Assert.IsTrue(math.frexp(-27.34F, ref exponent) == -0.854375F);
            Assert.IsTrue(exponent == 5);
            Assert.IsTrue(math.frexp(0.25F, ref exponent) == 0.5F);
            Assert.IsTrue(exponent == -1);
            Assert.IsTrue(math.frexp(0.5F, ref exponent) == 0.5F);
            Assert.IsTrue(exponent == 0);
            Assert.IsTrue(math.frexp(1F, ref exponent) == 0.5F);
            Assert.IsTrue(exponent == 1);
            Assert.IsTrue(math.frexp(-1F, ref exponent) == -0.5F);
            Assert.IsTrue(exponent == 1);
            Assert.IsTrue(math.frexp(2F, ref exponent) == 0.5F);
            Assert.IsTrue(exponent == 2);
            Assert.IsTrue(math.frexp(4F, ref exponent) == 0.5F);
            Assert.IsTrue(exponent == 3);

            Assert.IsTrue(math.frexp(System.Math.Pow(2F, 127F), ref exponent) == 0.5F);
            Assert.IsTrue(exponent == 128);
            Assert.IsTrue(math.frexp(-System.Math.Pow(2F, 127F), ref exponent) == -0.5F);
            Assert.IsTrue(exponent == 128);
            Assert.IsTrue(math.frexp(System.Math.Pow(2F, -126F), ref exponent) == 0.5F);
            Assert.IsTrue(exponent == -125);
            Assert.IsTrue(math.frexp(System.Math.Pow(2F, -127F), ref exponent) == 0.5F);
            Assert.IsTrue(exponent == -126);
            Assert.IsTrue(math.frexp(System.Math.Pow(2F, -149F), ref exponent) == 0.5F);
            Assert.IsTrue(exponent == -148);
            Assert.IsTrue(math.frexp(-System.Math.Pow(2F, -149F), ref exponent) == -0.5F);
            Assert.IsTrue(exponent == -148);
        }

        [TestMethod]
        public void ilogb()
        {
            Assert.IsTrue(math.ilogb(System.Double.PositiveInfinity) == math.INT_MAX);
            Assert.IsTrue(math.ilogb(System.Double.NegativeInfinity) == math.INT_MAX);
            Assert.IsTrue(math.ilogb(0D) == math.FP_ILOGB0);
            Assert.IsTrue(math.ilogb(-0D) == math.FP_ILOGB0);
            Assert.IsTrue(math.ilogb(System.Double.NaN) == math.FP_ILOGBNAN);
            Assert.IsTrue(math.ilogb(-System.Double.NaN) == math.FP_ILOGBNAN);

            Assert.IsTrue(math.ilogb(1D) == 0);
            Assert.IsTrue(math.ilogb(System.Math.E) == 1);
            Assert.IsTrue(math.ilogb(1024D) == 10);
            Assert.IsTrue(math.ilogb(-2000D) == 10);

            Assert.IsTrue(math.ilogb(math.DBL_DENORM_MIN) == math.DBL_EXP_MIN - math.DBL_MANT_BITS);
            Assert.IsTrue(math.ilogb(-math.DBL_DENORM_MIN) == math.DBL_EXP_MIN - math.DBL_MANT_BITS);
            Assert.IsTrue(math.ilogb(math.DBL_DENORM_MAX) == math.DBL_EXP_MIN - 1);
            Assert.IsTrue(math.ilogb(-math.DBL_DENORM_MAX) == math.DBL_EXP_MIN - 1);

            Assert.IsTrue(math.ilogb(math.DBL_MIN) == math.DBL_EXP_MIN);
            Assert.IsTrue(math.ilogb(-math.DBL_MIN) == math.DBL_EXP_MIN);
            Assert.IsTrue(math.ilogb(math.DBL_MAX) == math.DBL_EXP_MAX);
            Assert.IsTrue(math.ilogb(-math.DBL_MAX) == math.DBL_EXP_MAX);

            Assert.IsTrue(math.ilogb(2D) == 1);
            Assert.IsTrue(math.ilogb(Math.Pow(2D, 56D)) == 56);
            Assert.IsTrue(math.ilogb(1.1D * Math.Pow(2D, -1074D)) == -1074);
            Assert.IsTrue(math.ilogb(Math.Pow(2D, -1075D)) == math.FP_ILOGB0);
            Assert.IsTrue(math.ilogb(Math.Pow(2D, 1024D)) == math.INT_MAX);
            Assert.IsTrue(math.ilogb(Math.Pow(2D, 1023D)) == 1023);
            Assert.IsTrue(math.ilogb(2D * Math.Pow(2D, 102D)) == 103);


            Assert.IsTrue(math.ilogb(System.Single.PositiveInfinity) == math.INT_MAX);
            Assert.IsTrue(math.ilogb(System.Single.NegativeInfinity) == math.INT_MAX);
            Assert.IsTrue(math.ilogb(0F) == math.FP_ILOGB0);
            Assert.IsTrue(math.ilogb(-0F) == math.FP_ILOGB0);
            Assert.IsTrue(math.ilogb(System.Single.NaN) == math.FP_ILOGBNAN);
            Assert.IsTrue(math.ilogb(-System.Single.NaN) == math.FP_ILOGBNAN);

            Assert.IsTrue(math.ilogb(1F) == 0);
            Assert.IsTrue(math.ilogb((float)System.Math.E) == 1);
            Assert.IsTrue(math.ilogb(1024F) == 10);
            Assert.IsTrue(math.ilogb(-2000F) == 10);

            Assert.IsTrue(math.ilogb(math.FLT_DENORM_MIN) == math.FLT_EXP_MIN - math.FLT_MANT_BITS);
            Assert.IsTrue(math.ilogb(-math.FLT_DENORM_MIN) == math.FLT_EXP_MIN - math.FLT_MANT_BITS);
            Assert.IsTrue(math.ilogb(math.FLT_DENORM_MAX) == math.FLT_EXP_MIN - 1);
            Assert.IsTrue(math.ilogb(-math.FLT_DENORM_MAX) == math.FLT_EXP_MIN - 1);

            Assert.IsTrue(math.ilogb(math.FLT_MIN) == math.FLT_EXP_MIN);
            Assert.IsTrue(math.ilogb(-math.FLT_MIN) == math.FLT_EXP_MIN);
            Assert.IsTrue(math.ilogb(math.FLT_MAX) == math.FLT_EXP_MAX);
            Assert.IsTrue(math.ilogb(-math.FLT_MAX) == math.FLT_EXP_MAX);

            Assert.IsTrue(math.ilogb(2F) == 1);
            Assert.IsTrue(math.ilogb((float)Math.Pow(2F, 56F)) == 56);
            Assert.IsTrue(math.ilogb(1.1F * (float)Math.Pow(2F, -149F)) == -149);
            Assert.IsTrue(math.ilogb((float)Math.Pow(2F, -150F)) == math.FP_ILOGB0);
            Assert.IsTrue(math.ilogb((float)Math.Pow(2F, 128F)) == math.INT_MAX);
            Assert.IsTrue(math.ilogb((float)Math.Pow(2D, 127F)) == 127);
            Assert.IsTrue(math.ilogb(2F * (float)Math.Pow(2F, 102F)) == 103);
        }

        [TestMethod]
        public void ldexp()
        {
            Assert.IsTrue(math.ldexp(0D, 0) == 0D);
            Assert.IsTrue(math.ldexp(-0D, 0) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-0D, 0)) == 1);

            Assert.IsTrue(math.ldexp(System.Double.PositiveInfinity, 1) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.ldexp(System.Double.NegativeInfinity, 1) == System.Double.NegativeInfinity);
            Assert.IsTrue(System.Double.IsNaN(math.ldexp(System.Double.NaN, 1)));
            Assert.IsTrue(System.Double.IsNaN(math.ldexp(-System.Double.NaN, 1)));

            Assert.IsTrue(math.ldexp(0.8D, 4) == 12.8D);
            Assert.IsTrue(math.ldexp(-0.854375D, 5) == -27.34D);
            Assert.IsTrue(math.ldexp(1D, 0) == 1D);

            Assert.IsTrue(math.ldexp(math.DBL_MIN / 2D, 0) == math.DBL_MIN / 2D);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN / 2D, 0) == -math.DBL_MIN / 2D);
            Assert.IsTrue(math.ldexp(math.DBL_MIN / 2D, 1) == math.DBL_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN / 2D, 1) == -math.DBL_MIN);

            Assert.IsTrue(math.ldexp(math.DBL_MIN, 0) == math.DBL_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN, 0) == -math.DBL_MIN);
            Assert.IsTrue(math.ldexp(math.DBL_DENORM_MIN, 0) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_DENORM_MIN, 0) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.DBL_DENORM_MIN, math.DBL_MANT_BITS) == math.DBL_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_DENORM_MIN, math.DBL_MANT_BITS) == -math.DBL_MIN);

            Assert.IsTrue(math.ldexp(math.DBL_MIN, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN, -math.DBL_MANT_BITS) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.DBL_MIN, -math.DBL_MANT_BITS - 1) == 0D);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN, -math.DBL_MANT_BITS - 1) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-math.DBL_MIN, -math.DBL_MANT_BITS - 1)) == 1);
            Assert.IsTrue(math.ldexp(math.DBL_MIN, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-math.DBL_MIN, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == 2D * math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == -2D * math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.ldexp(1D, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.ldexp(1D, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.ldexp(math.DBL_MAX, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.ldexp(math.DBL_MAX, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.ldexp(math.DBL_MIN, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.ldexp(math.DBL_MIN, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.ldexp(math.DBL_MIN / 4D, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.ldexp(math.DBL_MIN / 4D, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.ldexp(math.DBL_DENORM_MIN, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.ldexp(math.DBL_DENORM_MIN, System.Int32.MinValue) == 0D);

            Assert.IsTrue(math.ldexp(-1D, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-1D, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-1D, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.ldexp(-math.DBL_MAX, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-math.DBL_MAX, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-math.DBL_MAX, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-math.DBL_MIN, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN / 4D, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-math.DBL_MIN / 4D, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-math.DBL_MIN / 4D, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.ldexp(-math.DBL_DENORM_MIN, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-math.DBL_DENORM_MIN, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.ldexp(-math.DBL_DENORM_MIN, System.Int32.MinValue)) == 1);


            Assert.IsTrue(math.ldexp(0F, 0) == 0F);
            Assert.IsTrue(math.ldexp(-0F, 0) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-0F, 0)) == 1);

            Assert.IsTrue(math.ldexp(System.Single.PositiveInfinity, 1) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.ldexp(System.Single.NegativeInfinity, 1) == System.Single.NegativeInfinity);
            Assert.IsTrue(System.Single.IsNaN(math.ldexp(System.Single.NaN, 1)));
            Assert.IsTrue(System.Single.IsNaN(math.ldexp(-System.Single.NaN, 1)));

            Assert.IsTrue(math.ldexp(0.8F, 4) == 12.8F);
            Assert.IsTrue(math.ldexp(-0.854375F, 5) == -27.34F);
            Assert.IsTrue(math.ldexp(1F, 0) == 1F);

            Assert.IsTrue(math.ldexp(math.FLT_MIN / 2F, 0) == math.FLT_MIN / 2F);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN / 2F, 0) == -math.FLT_MIN / 2F);
            Assert.IsTrue(math.ldexp(math.FLT_MIN / 2F, 1) == math.FLT_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN / 2F, 1) == -math.FLT_MIN);

            Assert.IsTrue(math.ldexp(math.FLT_MIN, 0) == math.FLT_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN, 0) == -math.FLT_MIN);
            Assert.IsTrue(math.ldexp(math.FLT_DENORM_MIN, 0) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_DENORM_MIN, 0) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.FLT_DENORM_MIN, math.FLT_MANT_BITS) == math.FLT_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_DENORM_MIN, math.FLT_MANT_BITS) == -math.FLT_MIN);

            Assert.IsTrue(math.ldexp(math.FLT_MIN, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN, -math.FLT_MANT_BITS) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.FLT_MIN, -math.FLT_MANT_BITS - 1) == 0F);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN, -math.FLT_MANT_BITS - 1) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-math.FLT_MIN, -math.FLT_MANT_BITS - 1)) == 1);
            Assert.IsTrue(math.ldexp(math.FLT_MIN, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-math.FLT_MIN, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == 2F * math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == -2F * math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.ldexp(1F, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.ldexp(1F, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.ldexp(math.FLT_MAX, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.ldexp(math.FLT_MAX, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.ldexp(math.FLT_MIN, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.ldexp(math.FLT_MIN, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.ldexp(math.FLT_MIN / 4F, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.ldexp(math.FLT_MIN / 4F, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.ldexp(math.FLT_DENORM_MIN, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.ldexp(math.FLT_DENORM_MIN, System.Int32.MinValue) == 0F);

            Assert.IsTrue(math.ldexp(-1F, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-1F, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-1F, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.ldexp(-math.FLT_MAX, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-math.FLT_MAX, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-math.FLT_MAX, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-math.FLT_MIN, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN / 4F, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-math.FLT_MIN / 4F, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-math.FLT_MIN / 4F, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.ldexp(-math.FLT_DENORM_MIN, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.ldexp(-math.FLT_DENORM_MIN, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.ldexp(-math.FLT_DENORM_MIN, System.Int32.MinValue)) == 1);
        }

        [TestMethod]
        public void logb()
        {
            Assert.IsTrue(System.Double.IsPositiveInfinity(math.logb(System.Double.PositiveInfinity)));
            Assert.IsTrue(System.Double.IsPositiveInfinity(math.logb(System.Double.NegativeInfinity)));
            Assert.IsTrue(System.Double.IsNegativeInfinity(math.logb(0D)));
            Assert.IsTrue(System.Double.IsNegativeInfinity(math.logb(-0D)));
            Assert.IsTrue(System.Double.IsNaN(math.logb(System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.logb(-System.Double.NaN)));

            Assert.IsTrue(math.logb(1D) == 0D);
            Assert.IsTrue(math.logb(System.Math.E) == 1D);
            Assert.IsTrue(math.logb(1024D) == 10D);
            Assert.IsTrue(math.logb(-2000D) == 10D);

            Assert.IsTrue(math.logb(math.DBL_DENORM_MIN) == math.DBL_EXP_MIN - math.DBL_MANT_BITS);
            Assert.IsTrue(math.logb(-math.DBL_DENORM_MIN) == math.DBL_EXP_MIN - math.DBL_MANT_BITS);
            Assert.IsTrue(math.logb(math.DBL_DENORM_MAX) == math.DBL_EXP_MIN - 1);
            Assert.IsTrue(math.logb(-math.DBL_DENORM_MAX) == math.DBL_EXP_MIN - 1);

            Assert.IsTrue(math.logb(math.DBL_MIN) == math.DBL_EXP_MIN);
            Assert.IsTrue(math.logb(-math.DBL_MIN) == math.DBL_EXP_MIN);
            Assert.IsTrue(math.logb(math.DBL_MAX) == math.DBL_EXP_MAX);
            Assert.IsTrue(math.logb(-math.DBL_MAX) == math.DBL_EXP_MAX);

            Assert.IsTrue(math.logb(2D) == 1D);
            Assert.IsTrue(math.logb(Math.Pow(2D, 56D)) == 56D);
            Assert.IsTrue(math.logb(1.1D * Math.Pow(2D, -1074D)) == -1074D);
            Assert.IsTrue(math.logb(Math.Pow(2D, -1075D)) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.logb(Math.Pow(2D, 1024D)) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.logb(Math.Pow(2D, 1023D)) == 1023D);
            Assert.IsTrue(math.logb(2D * Math.Pow(2D, 102D)) == 103D);


            Assert.IsTrue(System.Single.IsPositiveInfinity(math.logb(System.Single.PositiveInfinity)));
            Assert.IsTrue(System.Single.IsPositiveInfinity(math.logb(System.Single.NegativeInfinity)));
            Assert.IsTrue(System.Single.IsNegativeInfinity(math.logb(0F)));
            Assert.IsTrue(System.Single.IsNegativeInfinity(math.logb(-0F)));
            Assert.IsTrue(System.Single.IsNaN(math.logb(System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.logb(-System.Single.NaN)));

            Assert.IsTrue(math.logb(1F) == 0F);
            Assert.IsTrue(math.logb((float)System.Math.E) == 1F);
            Assert.IsTrue(math.logb(1024F) == 10F);
            Assert.IsTrue(math.logb(-2000F) == 10F);

            Assert.IsTrue(math.logb(math.FLT_DENORM_MIN) == math.FLT_EXP_MIN - math.FLT_MANT_BITS);
            Assert.IsTrue(math.logb(-math.FLT_DENORM_MIN) == math.FLT_EXP_MIN - math.FLT_MANT_BITS);
            Assert.IsTrue(math.logb(math.FLT_DENORM_MAX) == math.FLT_EXP_MIN - 1);
            Assert.IsTrue(math.logb(-math.FLT_DENORM_MAX) == math.FLT_EXP_MIN - 1);

            Assert.IsTrue(math.logb(math.FLT_MIN) == math.FLT_EXP_MIN);
            Assert.IsTrue(math.logb(-math.FLT_MIN) == math.FLT_EXP_MIN);
            Assert.IsTrue(math.logb(math.FLT_MAX) == math.FLT_EXP_MAX);
            Assert.IsTrue(math.logb(-math.FLT_MAX) == math.FLT_EXP_MAX);

            Assert.IsTrue(math.logb(2F) == 1F);
            Assert.IsTrue(math.logb((float)Math.Pow(2F, 56F)) == 56F);
            Assert.IsTrue(math.logb(1.1F * (float)Math.Pow(2F, -149F)) == -149F);
            Assert.IsTrue(math.logb((float)Math.Pow(2F, -150F)) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.logb((float)Math.Pow(2F, 128F)) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.logb((float)Math.Pow(2D, 127F)) == 127F);
            Assert.IsTrue(math.logb(2F * (float)Math.Pow(2F, 102F)) == 103F);
        }

        [TestMethod]
        public void scalbn()
        {
            Assert.IsTrue(math.scalbn(0D, 0) == 0D);
            Assert.IsTrue(math.scalbn(-0D, 0) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-0D, 0)) == 1);

            Assert.IsTrue(math.scalbn(System.Double.PositiveInfinity, 1) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbn(System.Double.NegativeInfinity, 1) == System.Double.NegativeInfinity);
            Assert.IsTrue(System.Double.IsNaN(math.scalbn(System.Double.NaN, 1)));
            Assert.IsTrue(System.Double.IsNaN(math.scalbn(-System.Double.NaN, 1)));

            Assert.IsTrue(math.scalbn(0.8D, 4) == 12.8D);
            Assert.IsTrue(math.scalbn(-0.854375D, 5) == -27.34D);
            Assert.IsTrue(math.scalbn(1D, 0) == 1D);

            Assert.IsTrue(math.scalbn(math.DBL_MIN / 2D, 0) == math.DBL_MIN / 2D);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN / 2D, 0) == -math.DBL_MIN / 2D);
            Assert.IsTrue(math.scalbn(math.DBL_MIN / 2D, 1) == math.DBL_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN / 2D, 1) == -math.DBL_MIN);

            Assert.IsTrue(math.scalbn(math.DBL_MIN, 0) == math.DBL_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN, 0) == -math.DBL_MIN);
            Assert.IsTrue(math.scalbn(math.DBL_DENORM_MIN, 0) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_DENORM_MIN, 0) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.DBL_DENORM_MIN, math.DBL_MANT_BITS) == math.DBL_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_DENORM_MIN, math.DBL_MANT_BITS) == -math.DBL_MIN);

            Assert.IsTrue(math.scalbn(math.DBL_MIN, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN, -math.DBL_MANT_BITS) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.DBL_MIN, -math.DBL_MANT_BITS - 1) == 0D);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN, -math.DBL_MANT_BITS - 1) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-math.DBL_MIN, -math.DBL_MANT_BITS - 1)) == 1);
            Assert.IsTrue(math.scalbn(math.DBL_MIN, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-math.DBL_MIN, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == 2D * math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == -2D * math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbn(1D, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbn(1D, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.scalbn(math.DBL_MAX, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbn(math.DBL_MAX, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.scalbn(math.DBL_MIN, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbn(math.DBL_MIN, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.scalbn(math.DBL_MIN / 4D, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbn(math.DBL_MIN / 4D, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.scalbn(math.DBL_DENORM_MIN, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbn(math.DBL_DENORM_MIN, System.Int32.MinValue) == 0D);

            Assert.IsTrue(math.scalbn(-1D, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-1D, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-1D, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbn(-math.DBL_MAX, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-math.DBL_MAX, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-math.DBL_MAX, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-math.DBL_MIN, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN / 4D, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-math.DBL_MIN / 4D, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-math.DBL_MIN / 4D, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbn(-math.DBL_DENORM_MIN, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-math.DBL_DENORM_MIN, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbn(-math.DBL_DENORM_MIN, System.Int32.MinValue)) == 1);


            Assert.IsTrue(math.scalbn(0F, 0) == 0F);
            Assert.IsTrue(math.scalbn(-0F, 0) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-0F, 0)) == 1);

            Assert.IsTrue(math.scalbn(System.Single.PositiveInfinity, 1) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbn(System.Single.NegativeInfinity, 1) == System.Single.NegativeInfinity);
            Assert.IsTrue(System.Single.IsNaN(math.scalbn(System.Single.NaN, 1)));
            Assert.IsTrue(System.Single.IsNaN(math.scalbn(-System.Single.NaN, 1)));

            Assert.IsTrue(math.scalbn(0.8F, 4) == 12.8F);
            Assert.IsTrue(math.scalbn(-0.854375F, 5) == -27.34F);
            Assert.IsTrue(math.scalbn(1F, 0) == 1F);

            Assert.IsTrue(math.scalbn(math.FLT_MIN / 2F, 0) == math.FLT_MIN / 2F);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN / 2F, 0) == -math.FLT_MIN / 2F);
            Assert.IsTrue(math.scalbn(math.FLT_MIN / 2F, 1) == math.FLT_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN / 2F, 1) == -math.FLT_MIN);

            Assert.IsTrue(math.scalbn(math.FLT_MIN, 0) == math.FLT_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN, 0) == -math.FLT_MIN);
            Assert.IsTrue(math.scalbn(math.FLT_DENORM_MIN, 0) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_DENORM_MIN, 0) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.FLT_DENORM_MIN, math.FLT_MANT_BITS) == math.FLT_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_DENORM_MIN, math.FLT_MANT_BITS) == -math.FLT_MIN);

            Assert.IsTrue(math.scalbn(math.FLT_MIN, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN, -math.FLT_MANT_BITS) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.FLT_MIN, -math.FLT_MANT_BITS - 1) == 0F);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN, -math.FLT_MANT_BITS - 1) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-math.FLT_MIN, -math.FLT_MANT_BITS - 1)) == 1);
            Assert.IsTrue(math.scalbn(math.FLT_MIN, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-math.FLT_MIN, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == 2F * math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == -2F * math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbn(1F, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbn(1F, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.scalbn(math.FLT_MAX, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbn(math.FLT_MAX, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.scalbn(math.FLT_MIN, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbn(math.FLT_MIN, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.scalbn(math.FLT_MIN / 4F, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbn(math.FLT_MIN / 4F, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.scalbn(math.FLT_DENORM_MIN, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbn(math.FLT_DENORM_MIN, System.Int32.MinValue) == 0F);

            Assert.IsTrue(math.scalbn(-1F, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-1F, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-1F, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbn(-math.FLT_MAX, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-math.FLT_MAX, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-math.FLT_MAX, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-math.FLT_MIN, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN / 4F, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-math.FLT_MIN / 4F, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-math.FLT_MIN / 4F, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbn(-math.FLT_DENORM_MIN, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbn(-math.FLT_DENORM_MIN, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbn(-math.FLT_DENORM_MIN, System.Int32.MinValue)) == 1);
        }

        [TestMethod]
        public void scalbln()
        {
            Assert.IsTrue(math.scalbln(0D, 0L) == 0D);
            Assert.IsTrue(math.scalbln(-0D, 0L) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-0D, 0L)) == 1);

            Assert.IsTrue(math.scalbln(System.Double.PositiveInfinity, 1L) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(System.Double.NegativeInfinity, 1L) == System.Double.NegativeInfinity);
            Assert.IsTrue(System.Double.IsNaN(math.scalbln(System.Double.NaN, 1L)));
            Assert.IsTrue(System.Double.IsNaN(math.scalbln(-System.Double.NaN, 1L)));

            Assert.IsTrue(math.scalbln(0.8D, 4L) == 12.8D);
            Assert.IsTrue(math.scalbln(-0.854375D, 5L) == -27.34D);
            Assert.IsTrue(math.scalbln(1D, 0L) == 1D);

            Assert.IsTrue(math.scalbln(math.DBL_MIN / 2D, 0L) == math.DBL_MIN / 2D);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN / 2D, 0L) == -math.DBL_MIN / 2D);
            Assert.IsTrue(math.scalbln(math.DBL_MIN / 2D, 1L) == math.DBL_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN / 2D, 1L) == -math.DBL_MIN);

            Assert.IsTrue(math.scalbln(math.DBL_MIN, 0L) == math.DBL_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN, 0L) == -math.DBL_MIN);
            Assert.IsTrue(math.scalbln(math.DBL_DENORM_MIN, 0L) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_DENORM_MIN, 0L) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.DBL_DENORM_MIN, math.DBL_MANT_BITS) == math.DBL_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_DENORM_MIN, math.DBL_MANT_BITS) == -math.DBL_MIN);

            Assert.IsTrue(math.scalbln(math.DBL_MIN, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN, -math.DBL_MANT_BITS) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.DBL_MIN, -math.DBL_MANT_BITS - 1) == 0D);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN, -math.DBL_MANT_BITS - 1) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MIN, -math.DBL_MANT_BITS - 1)) == 1);
            Assert.IsTrue(math.scalbln(math.DBL_MIN, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MIN, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == 2D * math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == -2D * math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == -math.DBL_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2) == 0D);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbln(1D, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(1D, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.scalbln(math.DBL_MAX, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.DBL_MAX, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.scalbln(math.DBL_MIN, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.DBL_MIN, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.scalbln(math.DBL_MIN / 4D, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.DBL_MIN / 4D, System.Int32.MinValue) == 0D);
            Assert.IsTrue(math.scalbln(math.DBL_DENORM_MIN, System.Int32.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.DBL_DENORM_MIN, System.Int32.MinValue) == 0D);

            Assert.IsTrue(math.scalbln(-1D, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-1D, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-1D, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.DBL_MAX, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.DBL_MAX, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MAX, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MIN, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN / 4D, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN / 4D, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MIN / 4D, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.DBL_DENORM_MIN, System.Int32.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.DBL_DENORM_MIN, System.Int32.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_DENORM_MIN, System.Int32.MinValue)) == 1);

            Assert.IsTrue(math.scalbln(1D, System.Int64.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(1D, System.Int64.MinValue) == 0D);
            Assert.IsTrue(math.scalbln(math.DBL_MAX, System.Int64.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.DBL_MAX, System.Int64.MinValue) == 0D);
            Assert.IsTrue(math.scalbln(math.DBL_MIN, System.Int64.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.DBL_MIN, System.Int64.MinValue) == 0D);
            Assert.IsTrue(math.scalbln(math.DBL_MIN / 4D, System.Int64.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.DBL_MIN / 4D, System.Int64.MinValue) == 0D);
            Assert.IsTrue(math.scalbln(math.DBL_MIN, System.Int64.MaxValue) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.DBL_MIN, System.Int64.MinValue) == 0D);

            Assert.IsTrue(math.scalbln(-1D, System.Int64.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-1D, System.Int64.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-1D, System.Int64.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.DBL_MAX, System.Int64.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.DBL_MAX, System.Int64.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MAX, System.Int64.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN, System.Int64.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN, System.Int64.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MIN, System.Int64.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN / 4D, System.Int64.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.DBL_MIN / 4D, System.Int64.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_MIN / 4D, System.Int64.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.DBL_DENORM_MIN, System.Int64.MaxValue) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.DBL_DENORM_MIN, System.Int64.MinValue) == -0D);
            Assert.IsTrue(math.signbit(math.scalbln(-math.DBL_DENORM_MIN, System.Int64.MinValue)) == 1);


            Assert.IsTrue(math.scalbln(0F, 0L) == 0F);
            Assert.IsTrue(math.scalbln(-0F, 0L) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-0F, 0L)) == 1);

            Assert.IsTrue(math.scalbln(System.Single.PositiveInfinity, 1L) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(System.Single.NegativeInfinity, 1L) == System.Single.NegativeInfinity);
            Assert.IsTrue(System.Single.IsNaN(math.scalbln(System.Single.NaN, 1L)));
            Assert.IsTrue(System.Single.IsNaN(math.scalbln(-System.Single.NaN, 1L)));

            Assert.IsTrue(math.scalbln(0.8F, 4L) == 12.8F);
            Assert.IsTrue(math.scalbln(-0.854375F, 5L) == -27.34F);
            Assert.IsTrue(math.scalbln(1F, 0L) == 1F);

            Assert.IsTrue(math.scalbln(math.FLT_MIN / 2F, 0L) == math.FLT_MIN / 2F);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN / 2F, 0L) == -math.FLT_MIN / 2F);
            Assert.IsTrue(math.scalbln(math.FLT_MIN / 2F, 1L) == math.FLT_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN / 2F, 1L) == -math.FLT_MIN);

            Assert.IsTrue(math.scalbln(math.FLT_MIN, 0L) == math.FLT_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN, 0L) == -math.FLT_MIN);
            Assert.IsTrue(math.scalbln(math.FLT_DENORM_MIN, 0L) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_DENORM_MIN, 0L) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.FLT_DENORM_MIN, math.FLT_MANT_BITS) == math.FLT_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_DENORM_MIN, math.FLT_MANT_BITS) == -math.FLT_MIN);

            Assert.IsTrue(math.scalbln(math.FLT_MIN, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN, -math.FLT_MANT_BITS) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.FLT_MIN, -math.FLT_MANT_BITS - 1) == 0F);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN, -math.FLT_MANT_BITS - 1) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MIN, -math.FLT_MANT_BITS - 1)) == 1);
            Assert.IsTrue(math.scalbln(math.FLT_MIN, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MIN, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == 2F * math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == -2F * math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == -math.FLT_DENORM_MIN);
            Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2) == 0F);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 2)) == 1);

            Assert.IsTrue(math.scalbln(1F, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(1F, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.scalbln(math.FLT_MAX, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.FLT_MAX, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.scalbln(math.FLT_MIN, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.FLT_MIN, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.scalbln(math.FLT_MIN / 4F, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.FLT_MIN / 4F, System.Int32.MinValue) == 0F);
            Assert.IsTrue(math.scalbln(math.FLT_DENORM_MIN, System.Int32.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.FLT_DENORM_MIN, System.Int32.MinValue) == 0F);

            Assert.IsTrue(math.scalbln(-1F, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-1F, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-1F, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.FLT_MAX, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.FLT_MAX, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MAX, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MIN, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN / 4F, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN / 4F, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MIN / 4F, System.Int32.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.FLT_DENORM_MIN, System.Int32.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.FLT_DENORM_MIN, System.Int32.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_DENORM_MIN, System.Int32.MinValue)) == 1);

            Assert.IsTrue(math.scalbln(1F, System.Int64.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(1F, System.Int64.MinValue) == 0F);
            Assert.IsTrue(math.scalbln(math.FLT_MAX, System.Int64.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.FLT_MAX, System.Int64.MinValue) == 0F);
            Assert.IsTrue(math.scalbln(math.FLT_MIN, System.Int64.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.FLT_MIN, System.Int64.MinValue) == 0F);
            Assert.IsTrue(math.scalbln(math.FLT_MIN / 4F, System.Int64.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.FLT_MIN / 4F, System.Int64.MinValue) == 0F);
            Assert.IsTrue(math.scalbln(math.FLT_DENORM_MIN, System.Int64.MaxValue) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.scalbln(math.FLT_DENORM_MIN, System.Int64.MinValue) == 0F);

            Assert.IsTrue(math.scalbln(-1F, System.Int64.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-1F, System.Int64.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-1F, System.Int64.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.FLT_MAX, System.Int64.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.FLT_MAX, System.Int64.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MAX, System.Int64.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN, System.Int64.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN, System.Int64.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MIN, System.Int64.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN / 4F, System.Int64.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.FLT_MIN / 4F, System.Int64.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_MIN / 4F, System.Int64.MinValue)) == 1);
            Assert.IsTrue(math.scalbln(-math.FLT_DENORM_MIN, System.Int64.MaxValue) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.scalbln(-math.FLT_DENORM_MIN, System.Int64.MinValue) == -0F);
            Assert.IsTrue(math.signbit(math.scalbln(-math.FLT_DENORM_MIN, System.Int64.MinValue)) == 1);
        }

        [TestMethod]
        public void copysign()
        {
            {
                double result;

                result = math.copysign(0D, 0D);
                Assert.IsTrue(result == 0D && math.signbit(result) == 0);
                result = math.copysign(0D, -0D);
                Assert.IsTrue(result == -0D && math.signbit(result) == 1);
                result = math.copysign(-0D, 0D);
                Assert.IsTrue(result == 0D && math.signbit(result) == 0);
                result = math.copysign(-0D, -0D);
                Assert.IsTrue(result == -0D && math.signbit(result) == 1);

                result = math.copysign(0D, 4D);
                Assert.IsTrue(result == 0D && math.signbit(result) == 0);
                result = math.copysign(0D, -4D);
                Assert.IsTrue(result == -0D && math.signbit(result) == 1);
                result = math.copysign(-0D, 4D);
                Assert.IsTrue(result == 0D && math.signbit(result) == 0);
                result = math.copysign(-0D, -4D);
                Assert.IsTrue(result == -0D && math.signbit(result) == 1);

                Assert.IsTrue(math.copysign(2D, 0D) == 2D);
                Assert.IsTrue(math.copysign(2D, -0D) == -2D);
                Assert.IsTrue(math.copysign(-2D, 0D) == 2D);
                Assert.IsTrue(math.copysign(-2D, -0D) == -2D);

                result = math.copysign(System.Double.PositiveInfinity, 0D);
                Assert.IsTrue(result == System.Double.PositiveInfinity && math.signbit(result) == 0);
                result = math.copysign(System.Double.PositiveInfinity, -0D);
                Assert.IsTrue(result == System.Double.NegativeInfinity && math.signbit(result) == 1);
                result = math.copysign(System.Double.NegativeInfinity, 0D);
                Assert.IsTrue(result == System.Double.PositiveInfinity && math.signbit(result) == 0);
                result = math.copysign(System.Double.NegativeInfinity, -0D);
                Assert.IsTrue(result == System.Double.NegativeInfinity && math.signbit(result) == 1);

                result = math.copysign(0D, System.Double.PositiveInfinity);
                Assert.IsTrue(result == 0D && math.signbit(result) == 0);
                result = math.copysign(0D, System.Double.NegativeInfinity);
                Assert.IsTrue(result == -0D && math.signbit(result) == 1);
                result = math.copysign(-0D, System.Double.PositiveInfinity);
                Assert.IsTrue(result == 0D && math.signbit(result) == 0);
                result = math.copysign(-0D, System.Double.NegativeInfinity);
                Assert.IsTrue(result == -0D && math.signbit(result) == 1);

                result = math.copysign(0D, System.Double.NaN);
                Assert.IsTrue(result == 0D && math.signbit(result) == 0);
                result = math.copysign(0D, -System.Double.NaN);
                Assert.IsTrue(result == -0D && math.signbit(result) == 1);
                result = math.copysign(-0D, System.Double.NaN);
                Assert.IsTrue(result == 0D && math.signbit(result) == 0);
                result = math.copysign(-0D, -System.Double.NaN);
                Assert.IsTrue(result == -0D && math.signbit(result) == 1);

                result = math.copysign(System.Double.NaN, 0D);
                Assert.IsTrue(System.Double.IsNaN(result) && math.signbit(result) == 0);
                result = math.copysign(System.Double.NaN, -0D);
                Assert.IsTrue(System.Double.IsNaN(result) && math.signbit(result) == 1);
                result = math.copysign(-System.Double.NaN, 0D);
                Assert.IsTrue(System.Double.IsNaN(result) && math.signbit(result) == 0);
                result = math.copysign(-System.Double.NaN, -0D);
                Assert.IsTrue(System.Double.IsNaN(result) && math.signbit(result) == 1);

                result = math.copysign(System.Double.NaN, System.Double.NaN);
                Assert.IsTrue(System.Double.IsNaN(result) && math.signbit(result) == 0);
                result = math.copysign(System.Double.NaN, -System.Double.NaN);
                Assert.IsTrue(System.Double.IsNaN(result) && math.signbit(result) == 1);
                result = math.copysign(-System.Double.NaN, System.Double.NaN);
                Assert.IsTrue(System.Double.IsNaN(result) && math.signbit(result) == 0);
                result = math.copysign(-System.Double.NaN, -System.Double.NaN);
                Assert.IsTrue(System.Double.IsNaN(result) && math.signbit(result) == 1);

                Assert.IsTrue(math.copysign(System.Double.MinValue, math.DBL_DENORM_MIN) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(System.Double.MinValue, -math.DBL_DENORM_MIN) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(-System.Double.MinValue, math.DBL_DENORM_MIN) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(-System.Double.MinValue, -math.DBL_DENORM_MIN) == System.Double.MinValue);

                Assert.IsTrue(math.copysign(math.DBL_DENORM_MIN, System.Double.MinValue) == -math.DBL_DENORM_MIN);
                Assert.IsTrue(math.copysign(math.DBL_DENORM_MIN, -System.Double.MinValue) == math.DBL_DENORM_MIN);
                Assert.IsTrue(math.copysign(-math.DBL_DENORM_MIN, System.Double.MinValue) == -math.DBL_DENORM_MIN);
                Assert.IsTrue(math.copysign(-math.DBL_DENORM_MIN, -System.Double.MinValue) == math.DBL_DENORM_MIN);

                Assert.IsTrue(math.copysign(System.Double.MaxValue, math.DBL_DENORM_MIN) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(System.Double.MaxValue, -math.DBL_DENORM_MIN) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(-System.Double.MaxValue, math.DBL_DENORM_MIN) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(-System.Double.MaxValue, -math.DBL_DENORM_MIN) == System.Double.MinValue);

                Assert.IsTrue(math.copysign(math.DBL_DENORM_MIN, System.Double.MaxValue) == math.DBL_DENORM_MIN);
                Assert.IsTrue(math.copysign(math.DBL_DENORM_MIN, -System.Double.MaxValue) == -math.DBL_DENORM_MIN);
                Assert.IsTrue(math.copysign(-math.DBL_DENORM_MIN, System.Double.MaxValue) == math.DBL_DENORM_MIN);
                Assert.IsTrue(math.copysign(-math.DBL_DENORM_MIN, -System.Double.MaxValue) == -math.DBL_DENORM_MIN);

                Assert.IsTrue(math.copysign(System.Double.MinValue, math.DBL_DENORM_MAX) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(System.Double.MinValue, -math.DBL_DENORM_MAX) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(-System.Double.MinValue, math.DBL_DENORM_MAX) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(-System.Double.MinValue, -math.DBL_DENORM_MAX) == System.Double.MinValue);

                Assert.IsTrue(math.copysign(math.DBL_DENORM_MAX, System.Double.MinValue) == -math.DBL_DENORM_MAX);
                Assert.IsTrue(math.copysign(math.DBL_DENORM_MAX, -System.Double.MinValue) == math.DBL_DENORM_MAX);
                Assert.IsTrue(math.copysign(-math.DBL_DENORM_MAX, System.Double.MinValue) == -math.DBL_DENORM_MAX);
                Assert.IsTrue(math.copysign(-math.DBL_DENORM_MAX, -System.Double.MinValue) == math.DBL_DENORM_MAX);

                Assert.IsTrue(math.copysign(System.Double.MaxValue, math.DBL_DENORM_MAX) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(System.Double.MaxValue, -math.DBL_DENORM_MAX) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(-System.Double.MaxValue, math.DBL_DENORM_MAX) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(-System.Double.MaxValue, -math.DBL_DENORM_MAX) == System.Double.MinValue);

                Assert.IsTrue(math.copysign(math.DBL_DENORM_MAX, System.Double.MaxValue) == math.DBL_DENORM_MAX);
                Assert.IsTrue(math.copysign(math.DBL_DENORM_MAX, -System.Double.MaxValue) == -math.DBL_DENORM_MAX);
                Assert.IsTrue(math.copysign(-math.DBL_DENORM_MAX, System.Double.MaxValue) == math.DBL_DENORM_MAX);
                Assert.IsTrue(math.copysign(-math.DBL_DENORM_MAX, -System.Double.MaxValue) == -math.DBL_DENORM_MAX);

                Assert.IsTrue(math.copysign(System.Double.MinValue, math.DBL_MIN) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(System.Double.MinValue, -math.DBL_MIN) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(-System.Double.MinValue, math.DBL_MIN) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(-System.Double.MinValue, -math.DBL_MIN) == System.Double.MinValue);

                Assert.IsTrue(math.copysign(math.DBL_MIN, System.Double.MinValue) == -math.DBL_MIN);
                Assert.IsTrue(math.copysign(math.DBL_MIN, -System.Double.MinValue) == math.DBL_MIN);
                Assert.IsTrue(math.copysign(-math.DBL_MIN, System.Double.MinValue) == -math.DBL_MIN);
                Assert.IsTrue(math.copysign(-math.DBL_MIN, -System.Double.MinValue) == math.DBL_MIN);

                Assert.IsTrue(math.copysign(System.Double.MaxValue, math.DBL_MIN) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(System.Double.MaxValue, -math.DBL_MIN) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(-System.Double.MaxValue, math.DBL_MIN) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(-System.Double.MaxValue, -math.DBL_MIN) == System.Double.MinValue);

                Assert.IsTrue(math.copysign(math.DBL_MIN, System.Double.MaxValue) == math.DBL_MIN);
                Assert.IsTrue(math.copysign(math.DBL_MIN, -System.Double.MaxValue) == -math.DBL_MIN);
                Assert.IsTrue(math.copysign(-math.DBL_MIN, System.Double.MaxValue) == math.DBL_MIN);
                Assert.IsTrue(math.copysign(-math.DBL_MIN, -System.Double.MaxValue) == -math.DBL_MIN);

                Assert.IsTrue(math.copysign(System.Double.MaxValue, System.Double.MinValue) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(System.Double.MaxValue, -System.Double.MinValue) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(-System.Double.MaxValue, System.Double.MinValue) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(-System.Double.MaxValue, -System.Double.MinValue) == System.Double.MaxValue);

                Assert.IsTrue(math.copysign(System.Double.MinValue, System.Double.MaxValue) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(System.Double.MinValue, -System.Double.MaxValue) == System.Double.MinValue);
                Assert.IsTrue(math.copysign(-System.Double.MinValue, System.Double.MaxValue) == System.Double.MaxValue);
                Assert.IsTrue(math.copysign(-System.Double.MinValue, -System.Double.MaxValue) == System.Double.MinValue);
            }

            {
                float result;

                result = math.copysign(0F, 0F);
                Assert.IsTrue(result == 0F && math.signbit(result) == 0);
                result = math.copysign(0F, -0F);
                Assert.IsTrue(result == -0F && math.signbit(result) == 1);
                result = math.copysign(-0F, 0F);
                Assert.IsTrue(result == 0F && math.signbit(result) == 0);
                result = math.copysign(-0F, -0F);
                Assert.IsTrue(result == -0F && math.signbit(result) == 1);

                result = math.copysign(0F, 4F);
                Assert.IsTrue(result == 0F && math.signbit(result) == 0);
                result = math.copysign(0F, -4F);
                Assert.IsTrue(result == -0F && math.signbit(result) == 1);
                result = math.copysign(-0F, 4F);
                Assert.IsTrue(result == 0F && math.signbit(result) == 0);
                result = math.copysign(-0F, -4F);
                Assert.IsTrue(result == -0F && math.signbit(result) == 1);

                Assert.IsTrue(math.copysign(2F, 0F) == 2F);
                Assert.IsTrue(math.copysign(2F, -0F) == -2F);
                Assert.IsTrue(math.copysign(-2F, 0F) == 2F);
                Assert.IsTrue(math.copysign(-2F, -0F) == -2F);

                result = math.copysign(System.Single.PositiveInfinity, 0F);
                Assert.IsTrue(result == System.Single.PositiveInfinity && math.signbit(result) == 0);
                result = math.copysign(System.Single.PositiveInfinity, -0F);
                Assert.IsTrue(result == System.Single.NegativeInfinity && math.signbit(result) == 1);
                result = math.copysign(System.Single.NegativeInfinity, 0F);
                Assert.IsTrue(result == System.Single.PositiveInfinity && math.signbit(result) == 0);
                result = math.copysign(System.Single.NegativeInfinity, -0F);
                Assert.IsTrue(result == System.Single.NegativeInfinity && math.signbit(result) == 1);

                result = math.copysign(0F, System.Single.PositiveInfinity);
                Assert.IsTrue(result == 0F && math.signbit(result) == 0);
                result = math.copysign(0F, System.Single.NegativeInfinity);
                Assert.IsTrue(result == -0F && math.signbit(result) == 1);
                result = math.copysign(-0F, System.Single.PositiveInfinity);
                Assert.IsTrue(result == 0F && math.signbit(result) == 0);
                result = math.copysign(-0F, System.Single.NegativeInfinity);
                Assert.IsTrue(result == -0F && math.signbit(result) == 1);

                result = math.copysign(0F, System.Single.NaN);
                Assert.IsTrue(result == 0F && math.signbit(result) == 0);
                result = math.copysign(0F, -System.Single.NaN);
                Assert.IsTrue(result == -0F && math.signbit(result) == 1);
                result = math.copysign(-0F, System.Single.NaN);
                Assert.IsTrue(result == 0F && math.signbit(result) == 0);
                result = math.copysign(-0F, -System.Single.NaN);
                Assert.IsTrue(result == -0F && math.signbit(result) == 1);

                result = math.copysign(System.Single.NaN, 0F);
                Assert.IsTrue(System.Single.IsNaN(result) && math.signbit(result) == 0);
                result = math.copysign(System.Single.NaN, -0F);
                Assert.IsTrue(System.Single.IsNaN(result) && math.signbit(result) == 1);
                result = math.copysign(-System.Single.NaN, 0F);
                Assert.IsTrue(System.Single.IsNaN(result) && math.signbit(result) == 0);
                result = math.copysign(-System.Single.NaN, -0F);
                Assert.IsTrue(System.Single.IsNaN(result) && math.signbit(result) == 1);

                result = math.copysign(System.Single.NaN, System.Single.NaN);
                Assert.IsTrue(System.Single.IsNaN(result) && math.signbit(result) == 0);
                result = math.copysign(System.Single.NaN, -System.Single.NaN);
                Assert.IsTrue(System.Single.IsNaN(result) && math.signbit(result) == 1);
                result = math.copysign(-System.Single.NaN, System.Single.NaN);
                Assert.IsTrue(System.Single.IsNaN(result) && math.signbit(result) == 0);
                result = math.copysign(-System.Single.NaN, -System.Single.NaN);
                Assert.IsTrue(System.Single.IsNaN(result) && math.signbit(result) == 1);

                Assert.IsTrue(math.copysign(System.Single.MinValue, math.FLT_DENORM_MIN) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(System.Single.MinValue, -math.FLT_DENORM_MIN) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(-System.Single.MinValue, math.FLT_DENORM_MIN) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(-System.Single.MinValue, -math.FLT_DENORM_MIN) == System.Single.MinValue);

                Assert.IsTrue(math.copysign(math.FLT_DENORM_MIN, System.Single.MinValue) == -math.FLT_DENORM_MIN);
                Assert.IsTrue(math.copysign(math.FLT_DENORM_MIN, -System.Single.MinValue) == math.FLT_DENORM_MIN);
                Assert.IsTrue(math.copysign(-math.FLT_DENORM_MIN, System.Single.MinValue) == -math.FLT_DENORM_MIN);
                Assert.IsTrue(math.copysign(-math.FLT_DENORM_MIN, -System.Single.MinValue) == math.FLT_DENORM_MIN);

                Assert.IsTrue(math.copysign(System.Single.MaxValue, math.FLT_DENORM_MIN) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(System.Single.MaxValue, -math.FLT_DENORM_MIN) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(-System.Single.MaxValue, math.FLT_DENORM_MIN) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(-System.Single.MaxValue, -math.FLT_DENORM_MIN) == System.Single.MinValue);

                Assert.IsTrue(math.copysign(math.FLT_DENORM_MIN, System.Single.MaxValue) == math.FLT_DENORM_MIN);
                Assert.IsTrue(math.copysign(math.FLT_DENORM_MIN, -System.Single.MaxValue) == -math.FLT_DENORM_MIN);
                Assert.IsTrue(math.copysign(-math.FLT_DENORM_MIN, System.Single.MaxValue) == math.FLT_DENORM_MIN);
                Assert.IsTrue(math.copysign(-math.FLT_DENORM_MIN, -System.Single.MaxValue) == -math.FLT_DENORM_MIN);

                Assert.IsTrue(math.copysign(System.Single.MinValue, math.FLT_DENORM_MAX) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(System.Single.MinValue, -math.FLT_DENORM_MAX) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(-System.Single.MinValue, math.FLT_DENORM_MAX) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(-System.Single.MinValue, -math.FLT_DENORM_MAX) == System.Single.MinValue);

                Assert.IsTrue(math.copysign(math.FLT_DENORM_MAX, System.Single.MinValue) == -math.FLT_DENORM_MAX);
                Assert.IsTrue(math.copysign(math.FLT_DENORM_MAX, -System.Single.MinValue) == math.FLT_DENORM_MAX);
                Assert.IsTrue(math.copysign(-math.FLT_DENORM_MAX, System.Single.MinValue) == -math.FLT_DENORM_MAX);
                Assert.IsTrue(math.copysign(-math.FLT_DENORM_MAX, -System.Single.MinValue) == math.FLT_DENORM_MAX);

                Assert.IsTrue(math.copysign(System.Single.MaxValue, math.FLT_DENORM_MAX) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(System.Single.MaxValue, -math.FLT_DENORM_MAX) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(-System.Single.MaxValue, math.FLT_DENORM_MAX) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(-System.Single.MaxValue, -math.FLT_DENORM_MAX) == System.Single.MinValue);

                Assert.IsTrue(math.copysign(math.FLT_DENORM_MAX, System.Single.MaxValue) == math.FLT_DENORM_MAX);
                Assert.IsTrue(math.copysign(math.FLT_DENORM_MAX, -System.Single.MaxValue) == -math.FLT_DENORM_MAX);
                Assert.IsTrue(math.copysign(-math.FLT_DENORM_MAX, System.Single.MaxValue) == math.FLT_DENORM_MAX);
                Assert.IsTrue(math.copysign(-math.FLT_DENORM_MAX, -System.Single.MaxValue) == -math.FLT_DENORM_MAX);

                Assert.IsTrue(math.copysign(System.Single.MinValue, math.FLT_MIN) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(System.Single.MinValue, -math.FLT_MIN) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(-System.Single.MinValue, math.FLT_MIN) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(-System.Single.MinValue, -math.FLT_MIN) == System.Single.MinValue);

                Assert.IsTrue(math.copysign(math.FLT_MIN, System.Single.MinValue) == -math.FLT_MIN);
                Assert.IsTrue(math.copysign(math.FLT_MIN, -System.Single.MinValue) == math.FLT_MIN);
                Assert.IsTrue(math.copysign(-math.FLT_MIN, System.Single.MinValue) == -math.FLT_MIN);
                Assert.IsTrue(math.copysign(-math.FLT_MIN, -System.Single.MinValue) == math.FLT_MIN);

                Assert.IsTrue(math.copysign(System.Single.MaxValue, math.FLT_MIN) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(System.Single.MaxValue, -math.FLT_MIN) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(-System.Single.MaxValue, math.FLT_MIN) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(-System.Single.MaxValue, -math.FLT_MIN) == System.Single.MinValue);

                Assert.IsTrue(math.copysign(math.FLT_MIN, System.Single.MaxValue) == math.FLT_MIN);
                Assert.IsTrue(math.copysign(math.FLT_MIN, -System.Single.MaxValue) == -math.FLT_MIN);
                Assert.IsTrue(math.copysign(-math.FLT_MIN, System.Single.MaxValue) == math.FLT_MIN);
                Assert.IsTrue(math.copysign(-math.FLT_MIN, -System.Single.MaxValue) == -math.FLT_MIN);

                Assert.IsTrue(math.copysign(System.Single.MaxValue, System.Single.MinValue) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(System.Single.MaxValue, -System.Single.MinValue) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(-System.Single.MaxValue, System.Single.MinValue) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(-System.Single.MaxValue, -System.Single.MinValue) == System.Single.MaxValue);

                Assert.IsTrue(math.copysign(System.Single.MinValue, System.Single.MaxValue) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(System.Single.MinValue, -System.Single.MaxValue) == System.Single.MinValue);
                Assert.IsTrue(math.copysign(-System.Single.MinValue, System.Single.MaxValue) == System.Single.MaxValue);
                Assert.IsTrue(math.copysign(-System.Single.MinValue, -System.Single.MaxValue) == System.Single.MinValue);
            }
        }

        [TestMethod]
        public void nextafter()
        {
            Assert.IsTrue(math.nextafter(0D, 0D) == 0D);
            Assert.IsTrue(math.nextafter(-0D, 0D) == 0D);
            Assert.IsTrue(math.nextafter(0D, -0D) == -0D);
            Assert.IsTrue(math.signbit(math.nextafter(0D, -0D)) == 1);
            Assert.IsTrue(math.nextafter(-0D, -0D) == -0D);
            Assert.IsTrue(math.signbit(math.nextafter(-0D, -0D)) == 1);

            Assert.IsTrue(math.nextafter(9D, 9D) == 9D);
            Assert.IsTrue(math.nextafter(-9D, -9D) == -9D);

            Assert.IsTrue(math.nextafter(System.Double.PositiveInfinity, System.Double.PositiveInfinity) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.nextafter(System.Double.NegativeInfinity, System.Double.NegativeInfinity) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.nextafter(System.Double.PositiveInfinity, System.Double.NegativeInfinity) == math.DBL_MAX);
            Assert.IsTrue(math.nextafter(System.Double.NegativeInfinity, System.Double.PositiveInfinity) == -math.DBL_MAX);
            Assert.IsTrue(math.nextafter(System.Double.PositiveInfinity, 0D) == math.DBL_MAX);
            Assert.IsTrue(math.nextafter(System.Double.NegativeInfinity, 0D) == -math.DBL_MAX);

            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, 0D)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, -0D)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, 100D)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, -100D)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, System.Double.PositiveInfinity)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, System.Double.NegativeInfinity)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, math.DBL_MIN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, math.DBL_MAX)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, math.DBL_DENORM_MIN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, math.DBL_DENORM_MAX)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, -math.DBL_MIN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, -math.DBL_MAX)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, -math.DBL_DENORM_MIN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, -math.DBL_DENORM_MAX)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, System.Double.NaN)));

            Assert.IsTrue(System.Double.IsNaN(math.nextafter(0D, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(-0D, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(100D, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(-100D, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.PositiveInfinity, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NegativeInfinity, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(math.DBL_MIN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(math.DBL_MAX, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(math.DBL_DENORM_MIN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(math.DBL_DENORM_MAX, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(-math.DBL_MIN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(-math.DBL_MAX, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(-math.DBL_DENORM_MIN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(-math.DBL_DENORM_MAX, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nextafter(System.Double.NaN, System.Double.NaN)));

            Assert.IsTrue(math.nextafter(math.DBL_MAX, System.Double.PositiveInfinity) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.nextafter(-math.DBL_MAX, System.Double.NegativeInfinity) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.nextafter(math.DBL_MIN, 0D) == math.DBL_DENORM_MAX);
            Assert.IsTrue(math.nextafter(-math.DBL_MIN, 0D) == -math.DBL_DENORM_MAX);
            Assert.IsTrue(math.nextafter(math.DBL_DENORM_MIN, 0D) == 0D);
            Assert.IsTrue(math.nextafter(-math.DBL_DENORM_MIN, 0D) == -0D);
            Assert.IsTrue(math.signbit(math.nextafter(-math.DBL_DENORM_MIN, 0D)) == 1);
            Assert.IsTrue(math.nextafter(math.DBL_MIN, -0D) == math.DBL_DENORM_MAX);
            Assert.IsTrue(math.nextafter(-math.DBL_MIN, -0D) == -math.DBL_DENORM_MAX);
            Assert.IsTrue(math.nextafter(math.DBL_DENORM_MIN, -0D) == 0D);
            Assert.IsTrue(math.nextafter(-math.DBL_DENORM_MIN, -0D) == -0D);
            Assert.IsTrue(math.signbit(math.nextafter(-math.DBL_DENORM_MIN, -0D)) == 1);
            Assert.IsTrue(math.nextafter(math.DBL_DENORM_MAX, System.Double.PositiveInfinity) == math.DBL_MIN);
            Assert.IsTrue(math.nextafter(-math.DBL_DENORM_MAX, System.Double.NegativeInfinity) == -math.DBL_MIN);

            Assert.IsTrue(math.mantissa(math.nextafter(1D, 2D)) == 1L);
            Assert.IsTrue(math.mantissa(math.nextafter(1D, 0.9D)) == 0xfffffffffffffL);
            Assert.IsTrue(math.mantissa(math.nextafter(-1D, -2D)) == 1L);
            Assert.IsTrue(math.mantissa(math.nextafter(-1D, -0.9D)) == 0xfffffffffffffL);


            Assert.IsTrue(math.nextafter(0F, 0F) == 0F);
            Assert.IsTrue(math.nextafter(-0F, 0F) == 0F);
            Assert.IsTrue(math.nextafter(0F, -0F) == -0F);
            Assert.IsTrue(math.signbit(math.nextafter(0F, -0F)) == 1);
            Assert.IsTrue(math.nextafter(-0F, -0F) == -0F);
            Assert.IsTrue(math.signbit(math.nextafter(-0F, -0F)) == 1);

            Assert.IsTrue(math.nextafter(9F, 9F) == 9F);
            Assert.IsTrue(math.nextafter(-9F, -9F) == -9F);

            Assert.IsTrue(math.nextafter(System.Single.PositiveInfinity, System.Single.PositiveInfinity) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.nextafter(System.Single.NegativeInfinity, System.Single.NegativeInfinity) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.nextafter(System.Single.PositiveInfinity, System.Single.NegativeInfinity) == math.FLT_MAX);
            Assert.IsTrue(math.nextafter(System.Single.NegativeInfinity, System.Single.PositiveInfinity) == -math.FLT_MAX);
            Assert.IsTrue(math.nextafter(System.Single.PositiveInfinity, 0F) == math.FLT_MAX);
            Assert.IsTrue(math.nextafter(System.Single.NegativeInfinity, 0F) == -math.FLT_MAX);

            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, 0F)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, -0F)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, 100F)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, -100F)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, System.Single.PositiveInfinity)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, System.Single.NegativeInfinity)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, math.FLT_MIN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, math.FLT_MAX)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, math.FLT_DENORM_MIN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, math.FLT_DENORM_MAX)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, -math.FLT_MIN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, -math.FLT_MAX)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, -math.FLT_DENORM_MIN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, -math.FLT_DENORM_MAX)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, System.Single.NaN)));

            Assert.IsTrue(System.Single.IsNaN(math.nextafter(0F, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(-0F, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(100F, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(-100F, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.PositiveInfinity, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NegativeInfinity, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(math.FLT_MIN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(math.FLT_MAX, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(math.FLT_DENORM_MIN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(math.FLT_DENORM_MAX, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(-math.FLT_MIN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(-math.FLT_MAX, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(-math.FLT_DENORM_MIN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(-math.FLT_DENORM_MAX, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nextafter(System.Single.NaN, System.Single.NaN)));

            Assert.IsTrue(math.nextafter(math.FLT_MAX, System.Single.PositiveInfinity) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.nextafter(-math.FLT_MAX, System.Single.NegativeInfinity) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.nextafter(math.FLT_MIN, 0F) == math.FLT_DENORM_MAX);
            Assert.IsTrue(math.nextafter(-math.FLT_MIN, 0F) == -math.FLT_DENORM_MAX);
            Assert.IsTrue(math.nextafter(math.FLT_DENORM_MIN, 0F) == 0F);
            Assert.IsTrue(math.nextafter(-math.FLT_DENORM_MIN, 0F) == -0F);
            Assert.IsTrue(math.signbit(math.nextafter(-math.FLT_DENORM_MIN, 0F)) == 1);
            Assert.IsTrue(math.nextafter(math.FLT_MIN, -0F) == math.FLT_DENORM_MAX);
            Assert.IsTrue(math.nextafter(-math.FLT_MIN, -0F) == -math.FLT_DENORM_MAX);
            Assert.IsTrue(math.nextafter(math.FLT_DENORM_MIN, -0F) == 0F);
            Assert.IsTrue(math.nextafter(-math.FLT_DENORM_MIN, -0F) == -0F);
            Assert.IsTrue(math.signbit(math.nextafter(-math.FLT_DENORM_MIN, -0F)) == 1);
            Assert.IsTrue(math.nextafter(math.FLT_DENORM_MAX, System.Single.PositiveInfinity) == math.FLT_MIN);
            Assert.IsTrue(math.nextafter(-math.FLT_DENORM_MAX, System.Single.NegativeInfinity) == -math.FLT_MIN);

            Assert.IsTrue(math.mantissa(math.nextafter(1F, 2F)) == 1L);
            Assert.IsTrue(math.mantissa(math.nextafter(1F, 0.9F)) == 0x7fffff);
            Assert.IsTrue(math.mantissa(math.nextafter(-1F, -2F)) == 1L);
            Assert.IsTrue(math.mantissa(math.nextafter(-1F, -0.9F)) == 0x7fffff);
        }

        [TestMethod]
        public void nexttoward()
        {
            Assert.IsTrue(math.nexttoward(0D, 0D) == 0D);
            Assert.IsTrue(math.nexttoward(-0D, 0D) == 0D);
            Assert.IsTrue(math.nexttoward(0D, -0D) == -0D);
            Assert.IsTrue(math.signbit(math.nexttoward(0D, -0D)) == 1);
            Assert.IsTrue(math.nexttoward(-0D, -0D) == -0D);
            Assert.IsTrue(math.signbit(math.nexttoward(-0D, -0D)) == 1);

            Assert.IsTrue(math.nexttoward(9D, 9D) == 9D);
            Assert.IsTrue(math.nexttoward(-9D, -9D) == -9D);

            Assert.IsTrue(math.nexttoward(System.Double.PositiveInfinity, System.Double.PositiveInfinity) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.nexttoward(System.Double.NegativeInfinity, System.Double.NegativeInfinity) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.nexttoward(System.Double.PositiveInfinity, System.Double.NegativeInfinity) == math.DBL_MAX);
            Assert.IsTrue(math.nexttoward(System.Double.NegativeInfinity, System.Double.PositiveInfinity) == -math.DBL_MAX);
            Assert.IsTrue(math.nexttoward(System.Double.PositiveInfinity, 0D) == math.DBL_MAX);
            Assert.IsTrue(math.nexttoward(System.Double.NegativeInfinity, 0D) == -math.DBL_MAX);

            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, 0D)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, -0D)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, 100D)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, -100D)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, System.Double.PositiveInfinity)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, System.Double.NegativeInfinity)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, math.DBL_MIN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, math.DBL_MAX)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, math.DBL_DENORM_MIN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, math.DBL_DENORM_MAX)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, -math.DBL_MIN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, -math.DBL_MAX)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, -math.DBL_DENORM_MIN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, -math.DBL_DENORM_MAX)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, System.Double.NaN)));

            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(0D, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(-0D, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(100D, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(-100D, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.PositiveInfinity, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NegativeInfinity, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(math.DBL_MIN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(math.DBL_MAX, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(math.DBL_DENORM_MIN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(math.DBL_DENORM_MAX, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(-math.DBL_MIN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(-math.DBL_MAX, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(-math.DBL_DENORM_MIN, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(-math.DBL_DENORM_MAX, System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.nexttoward(System.Double.NaN, System.Double.NaN)));

            Assert.IsTrue(math.nexttoward(math.DBL_MAX, System.Double.PositiveInfinity) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.nexttoward(-math.DBL_MAX, System.Double.NegativeInfinity) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.nexttoward(math.DBL_MIN, 0D) == math.DBL_DENORM_MAX);
            Assert.IsTrue(math.nexttoward(-math.DBL_MIN, 0D) == -math.DBL_DENORM_MAX);
            Assert.IsTrue(math.nexttoward(math.DBL_DENORM_MIN, 0D) == 0D);
            Assert.IsTrue(math.nexttoward(-math.DBL_DENORM_MIN, 0D) == -0D);
            Assert.IsTrue(math.signbit(math.nexttoward(-math.DBL_DENORM_MIN, 0D)) == 1);
            Assert.IsTrue(math.nexttoward(math.DBL_MIN, -0D) == math.DBL_DENORM_MAX);
            Assert.IsTrue(math.nexttoward(-math.DBL_MIN, -0D) == -math.DBL_DENORM_MAX);
            Assert.IsTrue(math.nexttoward(math.DBL_DENORM_MIN, -0D) == 0D);
            Assert.IsTrue(math.nexttoward(-math.DBL_DENORM_MIN, -0D) == -0D);
            Assert.IsTrue(math.signbit(math.nexttoward(-math.DBL_DENORM_MIN, -0D)) == 1);
            Assert.IsTrue(math.nexttoward(math.DBL_DENORM_MAX, System.Double.PositiveInfinity) == math.DBL_MIN);
            Assert.IsTrue(math.nexttoward(-math.DBL_DENORM_MAX, System.Double.NegativeInfinity) == -math.DBL_MIN);

            Assert.IsTrue(math.mantissa(math.nexttoward(1D, 2D)) == 1L);
            Assert.IsTrue(math.mantissa(math.nexttoward(1D, 0.9D)) == 0xfffffffffffffL);
            Assert.IsTrue(math.mantissa(math.nexttoward(-1D, -2D)) == 1L);
            Assert.IsTrue(math.mantissa(math.nexttoward(-1D, -0.9D)) == 0xfffffffffffffL);


            Assert.IsTrue(math.nexttoward(0F, 0F) == 0F);
            Assert.IsTrue(math.nexttoward(-0F, 0F) == 0F);
            Assert.IsTrue(math.nexttoward(0F, -0F) == -0F);
            Assert.IsTrue(math.signbit(math.nexttoward(0F, -0F)) == 1);
            Assert.IsTrue(math.nexttoward(-0F, -0F) == -0F);
            Assert.IsTrue(math.signbit(math.nexttoward(-0F, -0F)) == 1);

            Assert.IsTrue(math.nexttoward(9F, 9F) == 9F);
            Assert.IsTrue(math.nexttoward(-9F, -9F) == -9F);

            Assert.IsTrue(math.nexttoward(System.Single.PositiveInfinity, System.Single.PositiveInfinity) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.nexttoward(System.Single.NegativeInfinity, System.Single.NegativeInfinity) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.nexttoward(System.Single.PositiveInfinity, System.Single.NegativeInfinity) == math.FLT_MAX);
            Assert.IsTrue(math.nexttoward(System.Single.NegativeInfinity, System.Single.PositiveInfinity) == -math.FLT_MAX);
            Assert.IsTrue(math.nexttoward(System.Single.PositiveInfinity, 0F) == math.FLT_MAX);
            Assert.IsTrue(math.nexttoward(System.Single.NegativeInfinity, 0F) == -math.FLT_MAX);

            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, 0F)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, -0F)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, 100F)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, -100F)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, System.Single.PositiveInfinity)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, System.Single.NegativeInfinity)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, math.FLT_MIN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, math.FLT_MAX)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, math.FLT_DENORM_MIN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, math.FLT_DENORM_MAX)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, -math.FLT_MIN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, -math.FLT_MAX)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, -math.FLT_DENORM_MIN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, -math.FLT_DENORM_MAX)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, System.Single.NaN)));

            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(0F, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(-0F, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(100F, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(-100F, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.PositiveInfinity, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NegativeInfinity, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(math.FLT_MIN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(math.FLT_MAX, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(math.FLT_DENORM_MIN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(math.FLT_DENORM_MAX, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(-math.FLT_MIN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(-math.FLT_MAX, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(-math.FLT_DENORM_MIN, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(-math.FLT_DENORM_MAX, System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.nexttoward(System.Single.NaN, System.Single.NaN)));

            Assert.IsTrue(math.nexttoward(math.FLT_MAX, System.Single.PositiveInfinity) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.nexttoward(-math.FLT_MAX, System.Single.NegativeInfinity) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.nexttoward(math.FLT_MIN, 0F) == math.FLT_DENORM_MAX);
            Assert.IsTrue(math.nexttoward(-math.FLT_MIN, 0F) == -math.FLT_DENORM_MAX);
            Assert.IsTrue(math.nexttoward(math.FLT_DENORM_MIN, 0F) == 0F);
            Assert.IsTrue(math.nexttoward(-math.FLT_DENORM_MIN, 0F) == -0F);
            Assert.IsTrue(math.signbit(math.nexttoward(-math.FLT_DENORM_MIN, 0F)) == 1);
            Assert.IsTrue(math.nexttoward(math.FLT_MIN, -0F) == math.FLT_DENORM_MAX);
            Assert.IsTrue(math.nexttoward(-math.FLT_MIN, -0F) == -math.FLT_DENORM_MAX);
            Assert.IsTrue(math.nexttoward(math.FLT_DENORM_MIN, -0F) == 0F);
            Assert.IsTrue(math.nexttoward(-math.FLT_DENORM_MIN, -0F) == -0F);
            Assert.IsTrue(math.signbit(math.nexttoward(-math.FLT_DENORM_MIN, -0F)) == 1);
            Assert.IsTrue(math.nexttoward(math.FLT_DENORM_MAX, System.Single.PositiveInfinity) == math.FLT_MIN);
            Assert.IsTrue(math.nexttoward(-math.FLT_DENORM_MAX, System.Single.NegativeInfinity) == -math.FLT_MIN);

            Assert.IsTrue(math.mantissa(math.nexttoward(1F, 2F)) == 1L);
            Assert.IsTrue(math.mantissa(math.nexttoward(1F, 0.9F)) == 0x7fffff);
            Assert.IsTrue(math.mantissa(math.nexttoward(-1F, -2F)) == 1L);
            Assert.IsTrue(math.mantissa(math.nexttoward(-1F, -0.9F)) == 0x7fffff);
        }

        [TestMethod]
        public void exponent()
        {
            Assert.IsTrue(math.exponent(-System.Double.NaN) == (int)(math.DBL_EXP_MASK >> math.DBL_MANT_BITS));                 // 2047
            Assert.IsTrue(math.exponent(System.Double.NegativeInfinity) == (int)(math.DBL_EXP_MASK >> math.DBL_MANT_BITS));     // 2047
            Assert.IsTrue(math.exponent(-math.DBL_MAX) == math.DBL_EXP_MAX + math.DBL_EXP_BIAS);                                // 2046
            Assert.IsTrue(math.exponent(-1.5D) == 0 + math.DBL_EXP_BIAS);                                                       // 1023
            Assert.IsTrue(math.exponent(-0.75D) == -1 + math.DBL_EXP_BIAS);                                                     // 1022
            Assert.IsTrue(math.exponent(-0.5D) == -1 + math.DBL_EXP_BIAS);                                                      // 1022
            Assert.IsTrue(math.exponent(-math.DBL_MIN) == math.DBL_EXP_MIN + math.DBL_EXP_BIAS);                                // 1
            Assert.IsTrue(math.exponent(-math.DBL_DENORM_MAX) == 0);                                                            // 0
            Assert.IsTrue(math.exponent(-math.DBL_DENORM_MIN) == 0);                                                            // 0
            Assert.IsTrue(math.exponent(-0D) == 0);                                                                             // 0

            Assert.IsTrue(math.exponent(System.Double.NaN) == (int)(math.DBL_EXP_MASK >> math.DBL_MANT_BITS));                  // 2047
            Assert.IsTrue(math.exponent(System.Double.PositiveInfinity) == (int)(math.DBL_EXP_MASK >> math.DBL_MANT_BITS));     // 2047
            Assert.IsTrue(math.exponent(math.DBL_MAX) == math.DBL_EXP_MAX + math.DBL_EXP_BIAS);                                 // 2046
            Assert.IsTrue(math.exponent(1.5D) == 0 + math.DBL_EXP_BIAS);                                                        // 1023
            Assert.IsTrue(math.exponent(0.75D) == -1 + math.DBL_EXP_BIAS);                                                      // 1022
            Assert.IsTrue(math.exponent(0.5D) == -1 + math.DBL_EXP_BIAS);                                                       // 1022
            Assert.IsTrue(math.exponent(math.DBL_MIN) == math.DBL_EXP_MIN + math.DBL_EXP_BIAS);                                 // 1
            Assert.IsTrue(math.exponent(math.DBL_DENORM_MAX) == 0);                                                             // 0
            Assert.IsTrue(math.exponent(math.DBL_DENORM_MIN) == 0);                                                             // 0
            Assert.IsTrue(math.exponent(0D) == 0);                                                                              // 0

            Assert.IsTrue(math.exponent(-System.Single.NaN) == (int)(math.FLT_EXP_MASK >> math.FLT_MANT_BITS));                 // 255
            Assert.IsTrue(math.exponent(System.Single.NegativeInfinity) == (int)(math.FLT_EXP_MASK >> math.FLT_MANT_BITS));     // 255
            Assert.IsTrue(math.exponent(-math.FLT_MAX) == math.FLT_EXP_MAX + math.FLT_EXP_BIAS);                                // 254
            Assert.IsTrue(math.exponent(-1.5F) == 0 + math.FLT_EXP_BIAS);                                                       // 127
            Assert.IsTrue(math.exponent(-0.75F) == -1 + math.FLT_EXP_BIAS);                                                     // 126
            Assert.IsTrue(math.exponent(-0.5F) == -1 + math.FLT_EXP_BIAS);                                                      // 126
            Assert.IsTrue(math.exponent(-math.FLT_MIN) == math.FLT_EXP_MIN + math.FLT_EXP_BIAS);                                // 1
            Assert.IsTrue(math.exponent(-math.FLT_DENORM_MAX) == 0);                                                            // 0
            Assert.IsTrue(math.exponent(-math.FLT_DENORM_MIN) == 0);                                                            // 0
            Assert.IsTrue(math.exponent(-0F) == 0);                                                                             // 0

            Assert.IsTrue(math.exponent(System.Single.NaN) == (int)(math.FLT_EXP_MASK >> math.FLT_MANT_BITS));                  // 255
            Assert.IsTrue(math.exponent(System.Single.PositiveInfinity) == (int)(math.FLT_EXP_MASK >> math.FLT_MANT_BITS));     // 255
            Assert.IsTrue(math.exponent(math.FLT_MAX) == math.FLT_EXP_MAX + math.FLT_EXP_BIAS);                                 // 254
            Assert.IsTrue(math.exponent(1.5F) == 0 + math.FLT_EXP_BIAS);                                                        // 127
            Assert.IsTrue(math.exponent(0.75F) == -1 + math.FLT_EXP_BIAS);                                                      // 126
            Assert.IsTrue(math.exponent(0.5F) == -1 + math.FLT_EXP_BIAS);                                                       // 126
            Assert.IsTrue(math.exponent(math.FLT_MIN) == math.FLT_EXP_MIN + math.FLT_EXP_BIAS);                                 // 1
            Assert.IsTrue(math.exponent(math.FLT_DENORM_MAX) == 0);                                                             // 0
            Assert.IsTrue(math.exponent(math.FLT_DENORM_MIN) == 0);                                                             // 0
            Assert.IsTrue(math.exponent(0F) == 0);                                                                              // 0
        }

        [TestMethod]
        public void mantissa()
        {
            Assert.IsTrue(math.mantissa(0.5D) == 0L);
            Assert.IsTrue(math.mantissa(0.75D) == 0x8000000000000L);
            Assert.IsTrue(math.mantissa(math.DBL_MIN) == 0L);
            Assert.IsTrue(math.mantissa(math.DBL_DENORM_MIN) == 1L);
            Assert.IsTrue(math.mantissa(-math.DBL_MIN) == 0L);
            Assert.IsTrue(math.mantissa(-math.DBL_DENORM_MIN) == 1L);
            Assert.IsTrue(math.mantissa(math.DBL_MAX) == 0xFFFFFFFFFFFFFL);
            Assert.IsTrue(math.mantissa(math.DBL_DENORM_MAX) == 0xFFFFFFFFFFFFFL);
            Assert.IsTrue(math.mantissa(-math.DBL_MAX) == 0xFFFFFFFFFFFFFL);
            Assert.IsTrue(math.mantissa(-math.DBL_DENORM_MAX) == 0xFFFFFFFFFFFFFL);
            Assert.IsTrue(math.mantissa(System.Double.PositiveInfinity) == 0L);
            Assert.IsTrue(math.mantissa(System.Double.NegativeInfinity) == 0L);

            Assert.IsTrue(math.mantissa(0.5F) == 0);
            Assert.IsTrue(math.mantissa(0.75F) == 0x400000);
            Assert.IsTrue(math.mantissa(math.FLT_MIN) == 0);
            Assert.IsTrue(math.mantissa(math.FLT_DENORM_MIN) == 1);
            Assert.IsTrue(math.mantissa(-math.FLT_MIN) == 0);
            Assert.IsTrue(math.mantissa(-math.FLT_DENORM_MIN) == 1);
            Assert.IsTrue(math.mantissa(math.FLT_MAX) == 0x7FFFFF);
            Assert.IsTrue(math.mantissa(math.FLT_DENORM_MAX) == 0x7FFFFF);
            Assert.IsTrue(math.mantissa(-math.FLT_MAX) == 0x7FFFFF);
            Assert.IsTrue(math.mantissa(-math.FLT_DENORM_MAX) == 0x7FFFFF);
            Assert.IsTrue(math.mantissa(System.Single.PositiveInfinity) == 0);
            Assert.IsTrue(math.mantissa(System.Single.NegativeInfinity) == 0);
        }

        [TestMethod]
        public void significand()
        {
            Assert.IsTrue(System.Double.IsNaN(math.significand(System.Double.NaN)));
            Assert.IsTrue(System.Double.IsNaN(math.significand(-System.Double.NaN)));
            Assert.IsTrue(math.significand(System.Double.PositiveInfinity) == System.Double.PositiveInfinity);
            Assert.IsTrue(math.significand(System.Double.NegativeInfinity) == System.Double.NegativeInfinity);
            Assert.IsTrue(math.significand(0D) == 0D);
            Assert.IsTrue(math.significand(-0D) == -0D);
            Assert.IsTrue(math.signbit(math.significand(-0D)) == 1);
            Assert.IsTrue(math.significand(math.DBL_MIN) == 1D);
            Assert.IsTrue(math.significand(-math.DBL_MIN) == -1D);
            Assert.IsTrue(math.significand(math.DBL_DENORM_MIN) == 1D);
            Assert.IsTrue(math.significand(-math.DBL_DENORM_MIN) == -1D);
            Assert.IsTrue(math.significand(1D) == 1D);
            Assert.IsTrue(math.significand(-1D) == -1D);
            Assert.IsTrue(math.significand(4D) == 1D);
            Assert.IsTrue(math.significand(-4D) == -1D);
            Assert.IsTrue(math.significand(6D) == 1.5D);
            Assert.IsTrue(math.significand(-6D) == -1.5D);
            Assert.IsTrue(math.significand(7D) == 1.75D);
            Assert.IsTrue(math.significand(-7D) == -1.75D);
            Assert.IsTrue(math.significand(8D) == 1D);
            Assert.IsTrue(math.significand(-8D) == -1D);

            Assert.IsTrue(System.Single.IsNaN(math.significand(System.Single.NaN)));
            Assert.IsTrue(System.Single.IsNaN(math.significand(-System.Single.NaN)));
            Assert.IsTrue(math.significand(System.Single.PositiveInfinity) == System.Single.PositiveInfinity);
            Assert.IsTrue(math.significand(System.Single.NegativeInfinity) == System.Single.NegativeInfinity);
            Assert.IsTrue(math.significand(0F) == 0F);
            Assert.IsTrue(math.significand(-0F) == -0F);
            Assert.IsTrue(math.signbit(math.significand(-0F)) == 1);
            Assert.IsTrue(math.significand(math.FLT_MIN) == 1F);
            Assert.IsTrue(math.significand(-math.FLT_MIN) == -1F);
            Assert.IsTrue(math.significand(math.FLT_DENORM_MIN) == 1F);
            Assert.IsTrue(math.significand(-math.FLT_DENORM_MIN) == -1F);
            Assert.IsTrue(math.significand(1F) == 1F);
            Assert.IsTrue(math.significand(-1F) == -1F);
            Assert.IsTrue(math.significand(4F) == 1F);
            Assert.IsTrue(math.significand(-4F) == -1F);
            Assert.IsTrue(math.significand(6F) == 1.5F);
            Assert.IsTrue(math.significand(-6F) == -1.5F);
            Assert.IsTrue(math.significand(7F) == 1.75F);
            Assert.IsTrue(math.significand(-7F) == -1.75F);
            Assert.IsTrue(math.significand(8F) == 1F);
            Assert.IsTrue(math.significand(-8F) == -1F);
        }

        [TestMethod]
        public void isunordered()
        {
            Assert.IsFalse(math.isunordered(-0D, -0D));
            Assert.IsFalse(math.isunordered(-0D, 0D));
            Assert.IsFalse(math.isunordered(-0D, 1F));
            Assert.IsTrue(math.isunordered(-0D, System.Double.NaN));
            Assert.IsTrue(math.isunordered(-0D, -System.Double.NaN));
            Assert.IsFalse(math.isunordered(0D, -0D));
            Assert.IsFalse(math.isunordered(0D, 0D));
            Assert.IsFalse(math.isunordered(0D, 1F));
            Assert.IsTrue(math.isunordered(0D, System.Double.NaN));
            Assert.IsTrue(math.isunordered(0D, -System.Double.NaN));
            Assert.IsFalse(math.isunordered(1F, -0D));
            Assert.IsFalse(math.isunordered(1F, 0D));
            Assert.IsFalse(math.isunordered(1F, 1F));
            Assert.IsTrue(math.isunordered(1F, System.Double.NaN));
            Assert.IsTrue(math.isunordered(1F, -System.Double.NaN));
            Assert.IsTrue(math.isunordered(System.Double.NaN, -0D));
            Assert.IsTrue(math.isunordered(-System.Double.NaN, -0D));
            Assert.IsTrue(math.isunordered(System.Double.NaN, 0D));
            Assert.IsTrue(math.isunordered(-System.Double.NaN, 0D));
            Assert.IsTrue(math.isunordered(System.Double.NaN, 1F));
            Assert.IsTrue(math.isunordered(-System.Double.NaN, 1F));
            Assert.IsTrue(math.isunordered(System.Double.NaN, System.Double.NaN));
            Assert.IsTrue(math.isunordered(-System.Double.NaN, System.Double.NaN));
            Assert.IsTrue(math.isunordered(System.Double.NaN, -System.Double.NaN));
            Assert.IsTrue(math.isunordered(-System.Double.NaN, -System.Double.NaN));

            Assert.IsFalse(math.isunordered(-0F, -0F));
            Assert.IsFalse(math.isunordered(-0F, 0F));
            Assert.IsFalse(math.isunordered(-0F, 1D));
            Assert.IsTrue(math.isunordered(-0F, System.Single.NaN));
            Assert.IsTrue(math.isunordered(-0F, -System.Single.NaN));
            Assert.IsFalse(math.isunordered(0F, -0F));
            Assert.IsFalse(math.isunordered(0F, 0F));
            Assert.IsFalse(math.isunordered(0F, 1D));
            Assert.IsTrue(math.isunordered(0F, System.Single.NaN));
            Assert.IsTrue(math.isunordered(0F, -System.Single.NaN));
            Assert.IsFalse(math.isunordered(1F, -0F));
            Assert.IsFalse(math.isunordered(1F, 0F));
            Assert.IsFalse(math.isunordered(1F, 1D));
            Assert.IsTrue(math.isunordered(1F, System.Single.NaN));
            Assert.IsTrue(math.isunordered(1F, -System.Single.NaN));
            Assert.IsTrue(math.isunordered(System.Single.NaN, -0F));
            Assert.IsTrue(math.isunordered(-System.Single.NaN, -0F));
            Assert.IsTrue(math.isunordered(System.Single.NaN, 0F));
            Assert.IsTrue(math.isunordered(-System.Single.NaN, 0F));
            Assert.IsTrue(math.isunordered(System.Single.NaN, 1D));
            Assert.IsTrue(math.isunordered(-System.Single.NaN, 1D));
            Assert.IsTrue(math.isunordered(System.Single.NaN, System.Single.NaN));
            Assert.IsTrue(math.isunordered(-System.Single.NaN, System.Single.NaN));
            Assert.IsTrue(math.isunordered(System.Single.NaN, -System.Single.NaN));
            Assert.IsTrue(math.isunordered(-System.Single.NaN, -System.Single.NaN));
        }

    }
}
