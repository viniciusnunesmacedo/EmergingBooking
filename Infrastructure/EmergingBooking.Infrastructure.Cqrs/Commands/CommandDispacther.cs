using System;
using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Commands
{
    internal class CommandDispacther : ICommandDispacther
    {
        private readonly DependencyResolver dependencyResolver;

        public CommandDispacther(DependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public async Task<CommandResult> ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentException(nameof(command));

            var handler = dependencyResolver.Resolve<ICommandHandler<TCommand>>();

            return await handler.ExecuteAsync(command);
        }
    }
}
