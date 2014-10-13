﻿namespace ThreeCs.Math
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("Center = ({Center.X}, {Center.Y}, {Center.Z}), Radius = {Radius}")]
    public class Sphere
    {
        public Vector3 Center;

        public float Radius;

        /// <summary>
        /// 
        /// </summary>
        public Sphere()
        {
            this.Center = new Vector3();
            this.Radius = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public Sphere(Vector3 center, float radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="optionalCenter"></param>
        public void SetFromPoints(List<Vector3> points, Vector3 optionalCenter = null)
        {

            var box = new Box3();

			var center = this.Center;

            if ( optionalCenter != null ) {

                center = optionalCenter;

            } else {

                box.SetFromPoints(points).Center(center);

			}

			var maxRadiusSq = 0.0f;

            for ( var i = 0; i <  points.Count;  i ++ ) {
                maxRadiusSq = System.Math.Max(maxRadiusSq, center.DistanceToSquared(points[i]));
            }

			this.Radius = (float)System.Math.Sqrt( maxRadiusSq );

 		}
/*
       public void copy ( sphere ) {

		    this.center.copy( sphere.center );
		    this.radius = sphere.radius;

		    return this;

	    }

	    public void empty () {

		    return ( this.radius <= 0 );

	    }

	    public void containsPoint ( point ) {

		    return ( point.distanceToSquared( this.center ) <= ( this.radius * this.radius ) );

	    }

	    public void distanceToPoint ( point ) {

		    return ( point.distanceTo( this.center ) - this.radius );

	    }

	    public void intersectsSphere ( sphere ) {

		    var radiusSum = this.radius + sphere.radius;

		    return sphere.center.distanceToSquared( this.center ) <= ( radiusSum * radiusSum );

	    }

	    public void clampPoint ( point, optionalTarget ) {

		    var deltaLengthSq = this.center.distanceToSquared( point );

		    var result = optionalTarget || new THREE.Vector3();
		    result.copy( point );

		    if ( deltaLengthSq > ( this.radius * this.radius ) ) {

			    result.sub( this.center ).normalize();
			    result.multiplyScalar( this.radius ).add( this.center );

		    }

		    return result;

	    }

	    public void getBoundingBox ( optionalTarget ) {

		    var box = optionalTarget || new THREE.Box3();

		    box.set( this.center, this.center );
		    box.ExpandByScalar( this.radius );

		    return box;

	    }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
	    public Sphere applyMatrix4 (Matrix4 matrix )
        {
            this.Center.ApplyMatrix4(matrix);
		    this.Radius = this.Radius * matrix.GetMaxScaleOnAxis();
		    return this;

	    }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
	    public Sphere translate (object offset )
        {
            throw new NotImplementedException();
	//	    this.Center.add( offset );

		    return this;
	    }



	}
}