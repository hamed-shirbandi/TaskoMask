using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Cards;

namespace TaskoMask.Application.Core.ViewMoldes
{
   public class CardListViewModel
    {
        public BoardOutput Board { get; set; }
        public IEnumerable<CardOutputDto> Cards { get; set; }
    }
}
