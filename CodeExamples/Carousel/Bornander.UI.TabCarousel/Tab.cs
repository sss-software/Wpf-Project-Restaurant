using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Bornander.Wpf.Meshes;

namespace Bornander.UI.TabCarousel
{
    class Tab
    {
        private readonly Material visualHostMaterial;
        private readonly MeshGeometry3D boxMesh;
        private readonly MeshGeometry3D visualMesh;

        private Viewport2DVisual3D front;
        private ModelVisual3D back;

        private FrameworkElement element;

        private double depth;

        public ModelVisual3D Model { get; private set; }

        public Tab(FrameworkElement element, Color color, double depth)
        {
            this.element = element;
            this.depth = depth;

            visualHostMaterial = new DiffuseMaterial(Brushes.White);
            visualHostMaterial.SetValue(Viewport2DVisual3D.IsVisualHostMaterialProperty, true);

            boxMesh = Box.CreateBoxMesh(1, 1, depth, Box.Side.Right | Box.Side.Left | Box.Side.Top | Box.Side.Bottom | Box.Side.Back);
            visualMesh = Box.CreateBoxMesh(1, 1, depth, Box.Side.Front);


            front = new Viewport2DVisual3D 
            { 
                Geometry = visualMesh, 
                Visual = element, 
                Material = visualHostMaterial 
            };


            back = new ModelVisual3D
            {
                Content = new GeometryModel3D
                {
                    Geometry = boxMesh,
                    Material = new DiffuseMaterial(Brushes.CadetBlue),
                }
            };

            Model = new ModelVisual3D();

            Model.Children.Add(back);
            Model.Children.Add(front);
        }

        public void UpdateTransform(int index, double angle, double radius)
        {
            TranslateTransform3D translaslation = new TranslateTransform3D(0, 0, radius - depth / 2.0);
            RotateTransform3D rotation = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), -index * angle));

            ScaleTransform3D scale = element != null ? new ScaleTransform3D(1.0, double.IsNaN(element.Height) ? 1.0 : element.Height / element.Width, 1.0) : new ScaleTransform3D(1, 1, 1);
            
            Transform3DGroup transform = new Transform3DGroup();

            transform.Children.Add(scale);
            transform.Children.Add(translaslation);
            transform.Children.Add(rotation);

            Model.Transform = transform;
        }

        public FrameworkElement Element
        {
            get { return element; }
            set
            {
                element = value;
                front.Visual = element;
            }
        }
    }
}
