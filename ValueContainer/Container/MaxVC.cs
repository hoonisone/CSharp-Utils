﻿using Hoonisone.ValueContainer2;
using System;

namespace Hoonisone.ValueContainer2.Container
{
    public class MaxVC<T> : ConstrainedVC<T> where T : IComparable
    {
        public MaxVC(T max, T value, bool autoHandling) : base(new MaxConstraint<T>(max), value, autoHandling) { }
        public MaxVC(T max, T value) : base(new MaxConstraint<T>(max), value) { }

        public T max { get { return ((MaxConstraint<T>)constraint).max; } }
    }
}
