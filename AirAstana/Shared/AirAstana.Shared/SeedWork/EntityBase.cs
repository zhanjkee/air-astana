using System;

namespace AirAstana.Shared.SeedWork
{
    /// <summary>
    ///     The base entity class.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///     Gets or sets the created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        ///     Gets or sets the modified date.
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        ///     Gets or sets the row version.
        /// </summary>
        public virtual byte[] RowVersion { get; set; }
    }
}
