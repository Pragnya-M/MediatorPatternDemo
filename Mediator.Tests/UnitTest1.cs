namespace Mediator.Structural.Tests
{
    public class MediatorTests
    {
        private readonly ConcreteMediator _mediator;
        private readonly ConcreteColleague1 _colleague1;
        private readonly ConcreteColleague2 _colleague2;

        public MediatorTests()
        {
            _mediator = new ConcreteMediator();
            _colleague1 = new ConcreteColleague1(_mediator);
            _colleague2 = new ConcreteColleague2(_mediator);

            _mediator.Colleague1 = _colleague1;
            _mediator.Colleague2 = _colleague2;
        }

        [Fact]
        public void Colleague1_SendMessage_Colleague2ReceivesMessage()
        {
            // Arrange
            string message = "How are you?";
            var output = CaptureConsoleOutput(() => _colleague1.Send(message));

            // Act & Assert
            Assert.Contains("Colleague2 gets message: " + message, output);
        }

        [Fact]
        public void Colleague2_SendMessage_Colleague1ReceivesMessage()
        {
            // Arrange
            string message = "Fine, thanks";
            var output = CaptureConsoleOutput(() => _colleague2.Send(message));

            // Act & Assert
            Assert.Contains("Colleague1 gets message: " + message, output);
        }

        // Helper method to capture Console output
        private string CaptureConsoleOutput(Action action)
        {
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);
            action();
            return consoleOutput.ToString().Trim();
        }
    }
}
