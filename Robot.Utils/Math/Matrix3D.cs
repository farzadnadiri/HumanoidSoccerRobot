using System;

namespace Robot.Locomotion.TrajectoryWalk
{
    public class Matrix3D
    {

        public const int M00 = 0,
            M01 = 1,
            M02 = 2,
            M03 = 3,
            M10 = 4,
            M11 = 5,
            M12 = 6,
            M13 = 7,
            M20 = 8,
            M21 = 9,
            M22 = 10,
            M23 = 11,
            M30 = 12,
            M31 = 13,
            M32 = 14,
            M33 = 15,
            MaxnumElement = 16;


        public double[] M;

        public Matrix3D()
        {
            M = new double[MaxnumElement];
            Identity();
        }

        public Matrix3D(Matrix3D m)
        {
            M = new double[MaxnumElement];
            //for (int i = 0; i < M.Length; i++)
            //{
            //    M[i] = m.M[i];
            //}
            Array.Copy(m.M, M, m.M.Length);
        }

        public void Identity()
        {
            M[M00] = 1; M[M01] = 0; M[M02] = 0; M[M03] = 0;
            M[M10] = 0; M[M11] = 1; M[M12] = 0; M[M13] = 0;
            M[M20] = 0; M[M21] = 0; M[M22] = 1; M[M23] = 0;
            M[M30] = 0; M[M31] = 0; M[M32] = 0; M[M33] = 1;
        }

        public bool Inverse()
        {
            var src = new Matrix3D();
            var dst = new Matrix3D();
            var tmp = new Matrix3D();

            /* transpose matrix */
            for (int i = 0; i < 4; i++)
            {
                src.M[i] = M[i * 4];
                src.M[i + 4] = M[i * 4 + 1];
                src.M[i + 8] = M[i * 4 + 2];
                src.M[i + 12] = M[i * 4 + 3];
            }

            /* calculate pairs for first 8 elements (cofactors) */
            tmp.M[0] = src.M[10] * src.M[15];
            tmp.M[1] = src.M[11] * src.M[14];
            tmp.M[2] = src.M[9] * src.M[15];
            tmp.M[3] = src.M[11] * src.M[13];
            tmp.M[4] = src.M[9] * src.M[14];
            tmp.M[5] = src.M[10] * src.M[13];
            tmp.M[6] = src.M[8] * src.M[15];
            tmp.M[7] = src.M[11] * src.M[12];
            tmp.M[8] = src.M[8] * src.M[14];
            tmp.M[9] = src.M[10] * src.M[12];
            tmp.M[10] = src.M[8] * src.M[13];
            tmp.M[11] = src.M[9] * src.M[12];
            /* calculate first 8 elements (cofactors) */
            dst.M[0] = (tmp.M[0] * src.M[5] + tmp.M[3] * src.M[6] + tmp.M[4] * src.M[7]) - (tmp.M[1] * src.M[5] + tmp.M[2] * src.M[6] + tmp.M[5] * src.M[7]);
            dst.M[1] = (tmp.M[1] * src.M[4] + tmp.M[6] * src.M[6] + tmp.M[9] * src.M[7]) - (tmp.M[0] * src.M[4] + tmp.M[7] * src.M[6] + tmp.M[8] * src.M[7]);
            dst.M[2] = (tmp.M[2] * src.M[4] + tmp.M[7] * src.M[5] + tmp.M[10] * src.M[7]) - (tmp.M[3] * src.M[4] + tmp.M[6] * src.M[5] + tmp.M[11] * src.M[7]);
            dst.M[3] = (tmp.M[5] * src.M[4] + tmp.M[8] * src.M[5] + tmp.M[11] * src.M[6]) - (tmp.M[4] * src.M[4] + tmp.M[9] * src.M[5] + tmp.M[10] * src.M[6]);
            dst.M[4] = (tmp.M[1] * src.M[1] + tmp.M[2] * src.M[2] + tmp.M[5] * src.M[3]) - (tmp.M[0] * src.M[1] + tmp.M[3] * src.M[2] + tmp.M[4] * src.M[3]);
            dst.M[5] = (tmp.M[0] * src.M[0] + tmp.M[7] * src.M[2] + tmp.M[8] * src.M[3]) - (tmp.M[1] * src.M[0] + tmp.M[6] * src.M[2] + tmp.M[9] * src.M[3]);
            dst.M[6] = (tmp.M[3] * src.M[0] + tmp.M[6] * src.M[1] + tmp.M[11] * src.M[3]) - (tmp.M[2] * src.M[0] + tmp.M[7] * src.M[1] + tmp.M[10] * src.M[3]);
            dst.M[7] = (tmp.M[4] * src.M[0] + tmp.M[9] * src.M[1] + tmp.M[10] * src.M[2]) - (tmp.M[5] * src.M[0] + tmp.M[8] * src.M[1] + tmp.M[11] * src.M[2]);
            /* calculate pairs for second 8 elements (cofactors) */
            tmp.M[0] = src.M[2] * src.M[7];
            tmp.M[1] = src.M[3] * src.M[6];
            tmp.M[2] = src.M[1] * src.M[7];
            tmp.M[3] = src.M[3] * src.M[5];
            tmp.M[4] = src.M[1] * src.M[6];
            tmp.M[5] = src.M[2] * src.M[5];
            //Streaming SIMD Extensions - Inverse of 4x4 Matrix 8
            tmp.M[6] = src.M[0] * src.M[7];
            tmp.M[7] = src.M[3] * src.M[4];
            tmp.M[8] = src.M[0] * src.M[6];
            tmp.M[9] = src.M[2] * src.M[4];
            tmp.M[10] = src.M[0] * src.M[5];
            tmp.M[11] = src.M[1] * src.M[4];
            /* calculate second 8 elements (cofactors) */
            dst.M[8] = (tmp.M[0] * src.M[13] + tmp.M[3] * src.M[14] + tmp.M[4] * src.M[15]) - (tmp.M[1] * src.M[13] + tmp.M[2] * src.M[14] + tmp.M[5] * src.M[15]);
            dst.M[9] = (tmp.M[1] * src.M[12] + tmp.M[6] * src.M[14] + tmp.M[9] * src.M[15]) - (tmp.M[0] * src.M[12] + tmp.M[7] * src.M[14] + tmp.M[8] * src.M[15]);
            dst.M[10] = (tmp.M[2] * src.M[12] + tmp.M[7] * src.M[13] + tmp.M[10] * src.M[15]) - (tmp.M[3] * src.M[12] + tmp.M[6] * src.M[13] + tmp.M[11] * src.M[15]);
            dst.M[11] = (tmp.M[5] * src.M[12] + tmp.M[8] * src.M[13] + tmp.M[11] * src.M[14]) - (tmp.M[4] * src.M[12] + tmp.M[9] * src.M[13] + tmp.M[10] * src.M[14]);
            dst.M[12] = (tmp.M[2] * src.M[10] + tmp.M[5] * src.M[11] + tmp.M[1] * src.M[9]) - (tmp.M[4] * src.M[11] + tmp.M[0] * src.M[9] + tmp.M[3] * src.M[10]);
            dst.M[13] = (tmp.M[8] * src.M[11] + tmp.M[0] * src.M[8] + tmp.M[7] * src.M[10]) - (tmp.M[6] * src.M[10] + tmp.M[9] * src.M[11] + tmp.M[1] * src.M[8]);
            dst.M[14] = (tmp.M[6] * src.M[9] + tmp.M[11] * src.M[11] + tmp.M[3] * src.M[8]) - (tmp.M[10] * src.M[11] + tmp.M[2] * src.M[8] + tmp.M[7] * src.M[9]);
            dst.M[15] = (tmp.M[10] * src.M[10] + tmp.M[4] * src.M[8] + tmp.M[9] * src.M[9]) - (tmp.M[8] * src.M[9] + tmp.M[11] * src.M[10] + tmp.M[5] * src.M[8]);
            /* calculate determinant */
            double det = src.M[0] * dst.M[0] + src.M[1] * dst.M[1] + src.M[2] * dst.M[2] + src.M[3] * dst.M[3];
            /* calculate matrix inverse */
            if (det == 0)
            {

                return false;
            }

            det = 1 / det;

            for (int i = 0; i < MaxnumElement; i++)
                M[i] = dst.M[i] * det;

            return true;
        }

        public void Scale(Vector3D scale)
        {
            var mat = new Matrix3D();
            mat.M[M00] = scale.X;
            mat.M[M11] = scale.Y;
            mat.M[M22] = scale.Z;
            (this * mat).M.CopyTo(M, 0);
        }

        public void Rotate(double angle, Vector3D axis)
        {
            double rad = angle * 3.141592 / 180.0;
            double c = Math.Cos(rad);
            double s = Math.Sin(rad);
            var mat = new Matrix3D();

            mat.M[M00] = c + axis.X * axis.X * (1 - c);
            mat.M[M01] = axis.X * axis.Y * (1 - c) - axis.Z * s;
            mat.M[M02] = axis.X * axis.Z * (1 - c) + axis.Y * s;
            mat.M[M10] = axis.X * axis.Y * (1 - c) + axis.Z * s;
            mat.M[M11] = c + axis.Y * axis.Y * (1 - c);
            mat.M[M12] = axis.Y * axis.Z * (1 - c) - axis.X * s;
            mat.M[M20] = axis.X * axis.Z * (1 - c) - axis.Y * s;
            mat.M[M21] = axis.Y * axis.Z * (1 - c) + axis.X * s;
            mat.M[M22] = c + axis.Z * axis.Z * (1 - c);

            (this * mat).M.CopyTo(M, 0);
        }

        public void Translate(Vector3D offset)
        {
            var mat=new Matrix3D();
            mat.M[M03] = offset.X;
            mat.M[M13] = offset.Y;
            mat.M[M23] = offset.Z;

            (this * mat).M.CopyTo(M, 0);
        }

        public Point3D Transform(Point3D point)
        {
            var result=new Point3D
            {
                X = M[M00]*point.X + M[M01]*point.Y + M[M02]*point.Z + M[M03],
                Y = M[M10]*point.X + M[M11]*point.Y + M[M12]*point.Z + M[M13],
                Z = M[M20]*point.X + M[M21]*point.Y + M[M22]*point.Z + M[M23]
            };

            return result;
        }

        public Vector3D Transform(Vector3D vector)
        {
            var result=new Vector3D
            {
                X = M[M00]*vector.X + M[M01]*vector.Y + M[M02]*vector.Z + M[M03],
                Y = M[M10]*vector.X + M[M11]*vector.Y + M[M12]*vector.Z + M[M13],
                Z = M[M20]*vector.X + M[M21]*vector.Y + M[M22]*vector.Z + M[M23]
            };

            return result;
        }

        public void SetTransform(Point3D point, Vector3D angle)
        {
            var cx = Math.Cos(angle.X * 3.141592 / 180.0);
            var cy = Math.Cos(angle.Y * 3.141592 / 180.0);
            var cz = Math.Cos(angle.Z * 3.141592 / 180.0);
            var sx = Math.Sin(angle.X * 3.141592 / 180.0);
            var sy = Math.Sin(angle.Y * 3.141592 / 180.0);
            var sz = Math.Sin(angle.Z * 3.141592 / 180.0);

            Identity();
            M[0] = cz * cy;
            M[1] = cz * sy * sx - sz * cx;
            M[2] = cz * sy * cx + sz * sx;
            M[3] = point.X;
            M[4] = sz * cy;
            M[5] = sz * sy * sx + cz * cx;
            M[6] = sz * sy * cx - cz * sx;
            M[7] = point.Y;
            M[8] = -sy;
            M[9] = cy * sx;
            M[10] = cy * cx;
            M[11] = point.Z;
        }

        public static Matrix3D operator *(Matrix3D a, Matrix3D mat)
        {
            var result = new Matrix3D();

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int c = 0; c < 4; c++)
                    {
                        result.M[j * 4 + i] += a.M[j * 4 + c] * mat.M[c * 4 + i];
                    }
                }
            }

            return result;
        }

    }
}
