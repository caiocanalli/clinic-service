using System;

namespace Clinic.Domain.Common
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Entity<TId> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (UnProxy(this) != UnProxy(other))
                return false;

            if (Id.Equals(default(TId)) || other.Id.Equals(default(TId)))
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (UnProxy(this).ToString() + Id).GetHashCode();
        }

        static Type UnProxy(object obj)
        {
            var type = obj.GetType();
            var typeString = type.ToString();
            return typeString.Contains("Castle.Proxies") ? type.BaseType : type;
        }
    }

    public abstract class Entity : Entity<long>
    {
        protected Entity()
        {
        }

        protected Entity(long id) : base(id)
        {
        }
    }
}