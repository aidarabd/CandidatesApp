﻿using System;
using System.Collections.Generic;

namespace Domain.SeedWork
{
    public abstract class Entity
    {
        int? _requestedHashCode;
        long _Id;
        
        public virtual long Id
        {
            get => _Id;
            protected set => _Id = value;
        }

        public bool IsTransient()
        {
            return Id == default(Int32);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity item)
                return false;

            if (ReferenceEquals(this, item))
                return true;

            if (GetType() != item.GetType())
                return false;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.Id == Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }
        
        public static bool operator ==(Entity? left, Entity? right)
        {
            if (Object.Equals(left, null))
                return Object.Equals(right, null);
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity? left, Entity? right)
        {
            return !(left == right);
        }
    }
}
