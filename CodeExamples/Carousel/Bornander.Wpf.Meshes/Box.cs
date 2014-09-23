using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace Bornander.Wpf.Meshes
{
    public class Box
    {
        [Flags]
        public enum Side : short
        {
            Front = 1,
            Right = 2,
            Back = 4,
            Left = 8,
            Bottom = 16,
            Top = 32
        }

        public static MeshGeometry3D CreateBoxMesh(double width, double height, double depth)
        {
            return CreateBoxMesh(width, height, depth, Side.Front | Side.Back | Side.Left | Side.Right | Side.Bottom | Side.Top);
        }

        public static MeshGeometry3D CreateBoxMesh(double width, double height, double depth, Side sides)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

            if ((sides & Side.Front) == Side.Front)
            {
                Plane.AddPlaneToMesh(
                    mesh,
                    new Vector3D(0, 0, 1),
                    new Point3D(-0.5 * width, 0.5 * height, 0.5 * depth),
                    new Point3D(-0.5 * width, -0.5 * height, 0.5 * depth),
                    new Point3D(0.5 * width, -0.5 * height, 0.5 * depth),
                    new Point3D(0.5 * width, 0.5 * height, 0.5 * depth));
            }

            if ((sides & Side.Right) == Side.Right)
            {
                Plane.AddPlaneToMesh(
                    mesh,
                    new Vector3D(1, 0, 0),
                    new Point3D(0.5 * width, 0.5 * height, 0.5 * depth),
                    new Point3D(0.5 * width, -0.5 * height, 0.5 * depth),
                    new Point3D(0.5 * width, -0.5 * height, -0.5 * depth),
                    new Point3D(0.5 * width, 0.5 * height, -0.5 * depth));
            }

            if ((sides & Side.Back) == Side.Back)
            {
                Plane.AddPlaneToMesh(
                    mesh,
                    new Vector3D(0, 0, -1),
                    new Point3D(0.5 * width, 0.5 * height, -0.5 * depth),
                    new Point3D(0.5 * width, -0.5 * height, -0.5 * depth),
                    new Point3D(-0.5 * width, -0.5 * height, -0.5 * depth),
                    new Point3D(-0.5 * width, 0.5 * height, -0.5 * depth));
            }

            if ((sides & Side.Left) == Side.Left)
            {
                Plane.AddPlaneToMesh(
                    mesh,
                    new Vector3D(-1, 0, 0),
                    new Point3D(-0.5 * width, 0.5 * height, -0.5 * depth),
                    new Point3D(-0.5 * width, -0.5 * height, -0.5 * depth),
                    new Point3D(-0.5 * width, -0.5 * height, 0.5 * depth),
                    new Point3D(-0.5 * width, 0.5 * height, 0.5 * depth));
            }

            if ((sides & Side.Bottom) == Side.Bottom)
            {
                Plane.AddPlaneToMesh(
                    mesh,
                    new Vector3D(0, -1, 0),
                    new Point3D(-0.5 * width, -0.5 * height, 0.5 * depth),
                    new Point3D(-0.5 * width, -0.5 * height, -0.5 * depth),
                    new Point3D(0.5 * width, -0.5 * height, -0.5 * depth),
                    new Point3D(0.5 * width, -0.5 * height, 0.5 * depth));
            }

            if ((sides & Side.Top) == Side.Top)
            {
                Plane.AddPlaneToMesh(
                    mesh,
                    new Vector3D(0, 1, 0),
                    new Point3D(-0.5 * width, 0.5 * height, -0.5 * depth),
                    new Point3D(-0.5 * width, 0.5 * height, 0.5 * depth),
                    new Point3D(0.5 * width, 0.5 * height, 0.5 * depth),
                    new Point3D(0.5 * width, 0.5 * height, -0.5 * depth));
            }

            return mesh;
        }
    }
}
