 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketsSport.Models
{
    /// <summary>
    /// Билет.
    /// </summary>
    [Table("tickets")]
    public class Ticket
    {
        /// <summary>
        /// Идентификатор. Уникальный ключ.
        /// </summary>
        [Column("id", TypeName = "serial")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор события.
        /// </summary>
        [Column("event_id", TypeName = "integer")]
        public int EventId { get; set; }

        /// <summary>
        /// Идентификатор пользователя - покупателя.
        /// </summary>
        [Column("user_id", TypeName = "integer")]
        public int? UserId { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [Column("price", TypeName = "integer")]
        public int Price { get; set; }

        /// <summary>
        /// Место
        /// </summary>
        [Column("place", TypeName = "integer")]
        public int Place { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [Column("status", TypeName = "varchar(150)")]
        public string Status { get; set; }

    }
}