CriptoPortfolio is application for manage and nonitoring cripto coins.

Multi-layer application architecture, MVVM.


Development process.

Added layer Domain. Inqluded models Coin and Transaction (many-to-many), IRepository, IUnitOfWork.
Added layer TestData (depends on Domain), inqluded test repository for Coin, for Transaction, TestUnitOfWork
Added layer Business(depends on Domain, TestData). Added managers for coin and transaction. Factory Method (Virtual Constructor).
Added references main prj -> Domain and portfolio.Business
Added ViewModelBase, MainWindowViewMode.
