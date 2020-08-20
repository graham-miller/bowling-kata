# First test

```
[Test]
public void TestGutterGame()
{
    var sut = new Game(); // 1. create empty game class

    for (var i = 0; i < 20; i++)
    {
        sut.Roll(0); // 2. create Roll with no implementation
    }

    Assert.That(sut.Score(), Is.EqualTo(0)); // 3. create Score returning -1
}
```

* Make it pass with simplest possible change: `return 0`.

# Second test

```
[Test]
public void TestAllOnes()
{
    var sut = new Game();

    for (var i = 0; i < 20; i++)
    {
        sut.Roll(1);
    }

    Assert.That(sut.Score(), Is.EqualTo(20));
}
```

* Notice duplication
* Make test pass
* Remove duplication

# Third test

```
[Test]
public void TestOneSpare()
{
    _sut.Roll(5);
    _sut.Roll(5); // spare
    _sut.Roll(3);
    RollMany(17, 0);
    Assert.That(_sut.Score(), Is.EqualTo(16));
}
```
* Ugly comment
* Could use flag to remember previous roll, but that seems a bit dirty, design is wrong.
* `Roll()` calculates score, but the name doesn't imply that.
* `Score()` implies it calculates the score, but doesn't.
Design is wrong, responsibilities are misplaced.
Comment out test and refactor:

```
private readonly int[] _rolls = new int[21];
private int _currentRoll;
```

Uncomment test and try:

```
if (_rolls[1] + _rolls[i+1] == 10) // spare
```

* This isn't going to work, might not be first ball or outside bounds of array
* Need to walk through array two balls at a time
* Make it pass.
* Refactor ugly comments and variable names

# Fourth test

```
[Test]
public void TestOneStrike()
{
    _sut.Roll(10); // strike
    _sut.Roll(3);
    _sut.Roll(4);
    RollMany(16, 0);
    Assert.That(_sut.Score(), Is.EqualTo(24));
}
```
* ugly comment
* Make test pass
* Ugly expressions
* Refactor

# Fifth test

```
[Test]
public void TestPerfectGame()
{
    RollMany(12, 10);
    Assert.That(_sut.Score(), Is.EqualTo(300));
}
```
