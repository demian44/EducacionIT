﻿using Microsoft.AspNetCore.SignalR;
using SignalRExample.Services;
using System.Threading.Tasks;

namespace SignalRExample.Hubs
{
    public class SquaresHub : Hub
    {
        private ISquareManager _manager;
        public SquaresHub(ISquareManager manager)
        { _manager = manager; }

        public async Task SwapColor(int rowIndex, int columnIndex)
        {
            _manager.SwapColor(rowIndex, columnIndex);
            await Clients.Others.SendAsync("SwapSquareColor", rowIndex, columnIndex);
        }
    }
}
