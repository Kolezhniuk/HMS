using System.Collections.Generic;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Measure.Commands
{
    public sealed class BulkInsertMeasureCommand : ICommand
    {
        public BulkInsertMeasureCommand(List<WriteMeasureDto> measureDtos)
        {
            MeasureDtos = measureDtos;
        }

        public List<WriteMeasureDto> MeasureDtos { get; }
    }
}