﻿using AudioSearchService.Application.Dto;
using AudioSearchService.Domain;
using MediatR;

namespace AudioSearchService.Application.CQRS.Command
{
    public class GetAudioSearchCommand : IRequest<List<AudioSearc>>
    {
        public string AudioSearch { get; set; }
        public int Count { get;set; }
    }
}