using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;

namespace Saraha.Infra.Service
{
    public class MessageService: IMessageService
    {

        private readonly IMessageRepository repo;
        public MessageService(IMessageRepository repo)
        {
            this.repo = repo;
        }

        public bool createMessage(Message message)
        {
            return repo.createMessage(message);
        }

        public bool deleteMessage(int? id)
        {
            return repo.deleteMessage(id);
        }

        public List<Message> getallMessage()
        {
            return repo.getallMessage();
        }

        public bool UpdateMessage(Message message)
        {
            return repo.UpdateMessage(message);
        }
    }
}
