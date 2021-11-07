CriptoPortfolio is application for manage and nonitoring cripto coins.

Multi-layer application architecture, MVVM.












Development process.

1. Added layer Domain. Inqluded models Coin and Transaction (many-to-many), IRepository, IUnitOfWork.
2. Added layer TestData (depends on Domain), inqluded test repository for Coin, for Transaction, TestUnitOfWork
3. Added layer Business(depends on Domain, TestData). Added managers for coin and transaction. Factory Method (Virtual Constructor).
4. Added references main prj -> Domain and portfolio.Business
5. Added ViewModelBase, MainWindowViewMode.
[...]