﻿using Shared;

namespace Domain.Command.Client
{
    public class DeleteClientCommand : IAsyncCommand
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public DeleteClientCommand(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
    }
}