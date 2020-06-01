using System;
using System.Diagnostics.CodeAnalysis;

namespace LojaHiper.Core.DomainObjects
{
    public abstract class Entity : IEquatable<Entity>
    {

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool Equals([AllowNull] Entity other)
        {
            return Id == other.Id;
        }

    }
}
