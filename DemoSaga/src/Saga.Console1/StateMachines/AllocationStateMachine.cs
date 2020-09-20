using System;
using Automatonymous;
using MassTransit;
using Message.Contracts.Events;

namespace Saga.Console1.StateMachines
{
    public class AllocationStateMachine :
          MassTransitStateMachine<AllocationState>
    {
        public AllocationStateMachine()
        {
            Console.WriteLine("Saga State machine ....");
            Event(() => CreateInitial, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => MoveToNextState1, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => MoveToNextState2, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => MoveToNextState3, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => MoveToNextState4, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => MoveToNextState5, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => RetryRaised, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => ErrorRaised, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => ExceptionRaised, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => FatalRaised, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => MoveToFinalize, x => x.CorrelateById(m => m.Message.PatientId));
            Event(() => Completed, x => x.CorrelateById(m => m.Message.PatientId));


            InstanceState(x => x.CurrentState);

            Initially(
                When(CreateInitial)
                    .Then(a => { Console.WriteLine("Received Event Create Initial" + a.Data.PatientId); })
                    .RespondAsync(x => x.Init<IInitialCreatedEvent>(new EventInitialCreatedEvent()
                    {
                        Name = "Initial Event Created",
                        PatientId = x.Data.PatientId,
                    }))
                    .TransitionTo(InitialState),
                When(ExceptionRaised)
                    .TransitionTo(ExceptionState)
            );

            During(InitialState,
                When(MoveToNextState1)
                    .Then(a => { Console.WriteLine("Received Event Moved To State-l  " + a.Data.PatientId); })
                    .RespondAsync(x => x.Init<IMoveToNextWork1>(new MoveToNextWork1()
                    {
                        Name = "Moved To State-l",
                        PatientId = x.Data.PatientId,
                    }))
                    .TransitionTo(State1),
                When(ExceptionRaised)
                    .TransitionTo(ExceptionState)
            );

            During(State1,
                When(MoveToNextState2)
                    .Then(a => { Console.WriteLine("Received Event Moved To State-2  " + a.Data.PatientId); })
                    .RespondAsync(x => x.Init<IMoveToNextWork2>(new MoveToNextWork2()
                    {
                        Name = "Moved To State-2",
                        PatientId = x.Data.PatientId,
                    }))
                    .TransitionTo(State2),

                When(ExceptionRaised)
                    .TransitionTo(ExceptionState),
                When(RetryRaised)
                    .TransitionTo(ReTryState),
                When(FatalRaised)
                    .TransitionTo(FatalState)
            );

            During(State2,
                When(MoveToNextState3)
                    .Then(a => { Console.WriteLine("Received Event Moved To State-3  " + a.Data.PatientId); })
                    .RespondAsync(x => x.Init<IMoveToNextWork3>(new MoveToNextWork3()
                    {
                        Name = "Moved To State-3",
                        PatientId = x.Data.PatientId,
                    }))
                    .TransitionTo(State3),
                When(ExceptionRaised)
                    .TransitionTo(ExceptionState)
            );
            During(State3,
                When(MoveToNextState4)
                    .Then(a => { Console.WriteLine("Received Event Moved To State-4  " + a.Data.PatientId); })
                    .RespondAsync(x => x.Init<IMoveToNextWork4>(new MoveToNextWork4()
                    {
                        Name = "Moved To State-4",
                        PatientId = x.Data.PatientId,
                    }))
                    .TransitionTo(State4),
                When(ExceptionRaised)
                    .TransitionTo(FinalState)
            );
            During(State4,
                When(MoveToNextState5)
                    .Then(a => { Console.WriteLine("Received Event Moved To State-5  " + a.Data.PatientId); })
                    .RespondAsync(x => x.Init<IMoveToNextWork5>(new MoveToNextWork5()
                    {
                        Name = "Moved To State-5",
                        PatientId = x.Data.PatientId,
                    }))
                    .TransitionTo(State5),
                When(ExceptionRaised)
                    .TransitionTo(ExceptionState)
            );

            During(State5,
                When(MoveToFinalize)
                    .Then(a => { Console.WriteLine("Received Event Move To finalize  " + a.Data.PatientId); })
                    .Finalize()
            );

            During(ExceptionState, FatalState, ErrorState, ReTryState,
                When(MoveToFinalize)
                    .Finalize()
            );

            SetCompletedWhenFinalized();
        }

        public State InitialState { get; set; }
        public State State1 { get; set; }
        public State State2 { get; set; }
        public State State3 { get; set; }
        public State State4 { get; set; }
        public State State5 { get; set; }
        public State ReTryState { get; set; }
        public State ErrorState { get; set; }
        public State ExceptionState { get; set; }
        public State FatalState { get; set; }
        public State FinalState { get; set; }

        public Event<IInitialCreateEvent> CreateInitial { get; set; }
        public Event<ICompletedWork1> MoveToNextState1 { get; set; }
        public Event<ICompletedWork2> MoveToNextState2 { get; set; }
        public Event<ICompletedWork3> MoveToNextState3 { get; set; }
        public Event<ICompletedWork4> MoveToNextState4 { get; set; }
        public Event<ICompletedWork5> MoveToNextState5 { get; set; }
        public Event<IRetryCurrentWork> RetryRaised { get; set; }
        public Event<IErrorCurrentWork> ErrorRaised { get; set; }
        public Event<IExceptionCurrentWork> ExceptionRaised { get; set; }
        public Event<IFatalCurrentWork> FatalRaised { get; set; }
        public Event<IFinalCompletedWork> MoveToFinalize { get; set; }
        public Event<ICompletedAllWork> Completed { get; set; }
    }

}