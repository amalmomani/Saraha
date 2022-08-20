﻿using System;
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

        public void CreateMessage(Message message)
        {
             repo.CreateMessage(message);
        }

        public void DeleteMessage(int? id)
        {
             repo.DeleteMessage(id);
        }

        public List<Message> GetallMessage()
        {
            return repo.GetallMessage();
        }

        public void UpdateMessage(Message message)
        {
             repo.UpdateMessage(message);
        }
    }
}
