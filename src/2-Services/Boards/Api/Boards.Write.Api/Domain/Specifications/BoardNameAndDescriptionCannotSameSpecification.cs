﻿using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.Services.Boards.Write.Api.Domain.Entities;

namespace TaskoMask.Services.Boards.Write.Api.Domain.Specifications
{
    internal class BoardNameAndDescriptionCannotSameSpecification : ISpecification<Board>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Board board)
        {
            return board.Name.Value.ToLower() != board.Description.Value?.ToLower();
        }
    }
}