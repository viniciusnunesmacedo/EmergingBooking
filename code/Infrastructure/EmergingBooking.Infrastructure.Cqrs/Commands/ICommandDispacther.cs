using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Commands
{
    public interface ICommandDispacther
    {
        Task<CommandResult> ExecuteAsync<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
