﻿using Microsoft.JSInterop.Infrastructure;
using SportsFixture.Dtos.Fixture;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static class MatchEventMapper
    {

        public static MatchEvent ToSportEventFromCreateDto(this CreateMatchEventDto dto)
        {
            return new MatchEvent
            {
                EventDateTime = dto.EventDateTime,
                EventName = dto.EventName,
                Referee = dto.Referee,
                StatusShort = dto.StatusShort,
                SportCompetitionId = dto.SportCompetitionId,
                Location = dto.Location,
                SportId = dto.SportId,
                HomeResult = dto.HomeResult,
                AwayResults = dto.AwayResults,
                HomeTeamId = dto.HomeTeamId,
                AwayTeamId = dto.AwayTeamId,

            };
        }

        public static MatchEvent ToMatchEventFromUpdateDto(this UpdateMatchEventDto dto, int id)
        {
            return new MatchEvent
            {
                Id = id,
                EventDateTime = dto.EventDateTime,
                EventName = dto.EventName,
                Referee = dto.Referee,
                StatusShort = dto.StatusShort,
                SportCompetitionId = dto.SportCompetitionId,
                Location = dto.Location,
                SportId = dto.SportId,
                HomeResult = dto.HomeResult,
                AwayResults = dto.AwayResults,
                HomeTeamId = dto.HomeTeamId,
                AwayTeamId = dto.AwayTeamId,

            };
        }

    }
}
