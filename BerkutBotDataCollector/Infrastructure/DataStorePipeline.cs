using System;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
	public class DataStorePipeline : IDataStorePipeline
	{
        private IList<IDataStoreStep> _steps = new List<IDataStoreStep>();
        private IDataStoreStep _firstStep;
        private IDataStoreStep _lastStep;

        public IDataStorePipeline AddStep(IDataStoreStep dataStoreStep)
        {
            if (_firstStep is null)
            {
                _firstStep = dataStoreStep;
                _lastStep = _firstStep;
                return this;
            }
            _lastStep = _lastStep.SetNext(dataStoreStep);
            return this;
        }

        public void Run(Message tgMessage)
        {
            _firstStep.Run(tgMessage);
        }
    }
}

