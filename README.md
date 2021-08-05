# Checkout Kata Technical Test

After reading the breif it is clear that this is aimed at handling the quirks of the special pricing
As it is test driven we need to look at all combinations of cases.

- single item
- multiples of single item
- enough quantity to make special offer valid on an item
- enough quantity to trigger special offer plus another x number of items
- enough quantity to trigger multiple special offers on an item
- all with above with multiple item types

There was also an emphesis on decoupling the items data from the checkout so it seems logical that the test is looking for its own repository
I have split the test into 3 projects Domain, Services and Test
The domain project will have our interface(s) and some simple models
The services project will have our checkout service implimentation
The test will have the above unit tests + a mock of the repository as no mention of its implimentation was mentioned or suggested