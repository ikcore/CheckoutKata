# Checkout Kata Technical Test

To run test just use CL command
```
dotnet test
```
or run tests in VS

After reading the breif it is clear that this is aimed at handling the quirks of the special pricing
As it is test driven we need to look at all combinations of cases.

- check item exists
- check for invalid item
- single item
- multiples of single item
- enough quantity to make special offer valid on an item
- enough quantity to trigger special offer plus another x number of items
- enough quantity to trigger multiple special offers on an item
- all with above with multiple item types

There was also an emphesis on decoupling the items data from the checkout so it seems logical that the test is looking for its own repository
I have split the test into 3 projects Domain, Services and Test
- The domain project will have our interface(s) and some simple models
- The services project will have our checkout service implimentation
- The test will have the above unit tests + a mock of the repository as no mention of its implimentation was mentioned or suggested

I have opted to inject the repository in the contructor of the checkout service as this seems like it will always be a requirement.
I can manually inject a mock repo for testing but because I'm using the IItemRepository interface this can be changed for other implimentations via DI

### Notes 
The unit price type is an int so that needs to be consitant
I have implimented simple exceptions. In real world app I would impliment custom exceptions and define them as part of the domain
