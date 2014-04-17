using System;
using System.ComponentModel.DataAnnotations;
using NailsFramework.Persistence;

namespace AzureTest.Foundations
{
    public abstract class Entity<T> : Model<T> where T : Model<T>
    {
        public long Id { get; protected set; }

        [Required]
        public DateTime CreationDate { get; protected set; }

        protected Entity()
        {
            CreationDate = SystemDate.Now;
        }
    }
}