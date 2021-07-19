using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Services.Boards.Dto;
using TaskoMask.Application.Services.Cards.Dto;

namespace TaskoMask.Application.Queries.ViewMoldes
{
   public class CardListViewModel
    {
        public BoardOutput Board { get; set; }
        public IEnumerable<CardOutput> Cards { get; set; }
    }
}
