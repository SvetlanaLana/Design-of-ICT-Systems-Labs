using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainofResponsibility
{
    class Receiver
    {
        // банковские переводы
        public bool BankTransfer { get; set; }
        // денежные переводы - WesternUnion, Unistream
        public bool MoneyTransfer { get; set; }
        // перевод через PayPal
        public bool PayPalTransfer { get; set; }
        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }
    abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver);
    }
    class BankPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.BankTransfer == true)
                Console.WriteLine("Выполняем банковский перевод");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    class MoneyPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.MoneyTransfer == true)
                Console.WriteLine("Выполняем перевод через системы денежных переводов");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    class PayPalPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.PayPalTransfer == true)
                Console.WriteLine("Выполняем PayPal оплату");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver(false, true, true);
            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHnadler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymentHnadler;
            bankPaymentHandler.Handle(receiver);
            moneyPaymentHnadler.Successor = bankPaymentHandler;
            bankPaymentHandler.Successor = paypalPaymentHandler;
            moneyPaymentHnadler.Handle(receiver);
            Console.ReadKey();
        }
    }
    //    Паттерн Chain of Responsibility – паттерн поведения, предоставляющий возможность
    //    обработать запрос нескольким объектам, тем самым устраняет возможность связывания
    //    отправителя запроса с его получателем.Все возможные обработчики запроса образуют цепочку,
    //    а сам запрос перемещается по этой цепочке, пока один из ее объектов не обработает запрос

    //    Уменьшает зависимость между клиентом и обработчиком
    //    Реализет принцип единсвтенной ответственности
    //    Реализует принцип открытости/закрытости
    //
}
