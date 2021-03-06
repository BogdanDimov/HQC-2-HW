﻿using System;
using System.Windows.Media.Media3D;

namespace Surfaces
{
    public sealed class Circle : Surface
    {
        private static readonly PropertyHolder<double, Circle> RadiusProperty =
            new PropertyHolder<double, Circle>("Radius", 1.0, OnGeometryChanged);

        private static readonly PropertyHolder<Point3D, Circle> PositionProperty =
            new PropertyHolder<Point3D, Circle>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

        private Point3D _position;

        private double _radius;

        public double Radius
        {
            get { return RadiusProperty.Get(this); }
            set { RadiusProperty.Set(this, value); }
        }

        public Point3D Position
        {
            get { return PositionProperty.Get(this); }
            set { PositionProperty.Set(this, value); }
        }

        private Point3D PointForAngle(double angle)
        {
            return new Point3D(_position.X + _radius * Math.Cos(angle), _position.Y + _radius * Math.Sin(angle),
                _position.Z);
        }

        protected override Geometry3D CreateMesh()
        {
            _radius = Radius;
            _position = Position;

            var mesh = new MeshGeometry3D();
            var prevPoint = PointForAngle(0);
            var normal = new Vector3D(0, 0, 1);

            const int div = 180;
            for (var i = 1; i <= div; ++i)
            {
                var angle = 2 * Math.PI / div * i;
                var newPoint = PointForAngle(angle);
                mesh.Positions.Add(prevPoint);
                mesh.Positions.Add(_position);
                mesh.Positions.Add(newPoint);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                prevPoint = newPoint;
            }

            mesh.Freeze();
            return mesh;
        }
    }
}