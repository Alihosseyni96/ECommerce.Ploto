using ECommerce.Ploto.Common.Dommin.Exception;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    /// <summary>
    /// This is Abstract Class for entities
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public Guid? Createdby { get; set; }
        public DateTimeOffset? CreateAt { get; set; }




        private  List<INotification> _domainEvents;

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();


        public void AddDomainEvent(INotification domainEvent)
        {
            if(_domainEvents is null)
                _domainEvents = new List<INotification>();

            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(INotification domainEvent)
        {
            if(_domainEvents is null)
                throw new RemoveDomainEventException();

            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            if(_domainEvents is null)
                throw new ClearDomainEventException();

            _domainEvents.Clear();  

        }


    }
}
