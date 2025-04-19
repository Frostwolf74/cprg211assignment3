namespace Assignment3.Tests;

public class LinkedListTest
{
    private ILinkedListADT users;
    
    [SetUp]
    public void Setup()
    {
        users = new SLL();
        
        users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
        users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
        users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
        users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
    }

    [Test]
    public void GetValueTest()
    {
        User expectedUser = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
        
        Assert.That(users.GetValue(2).Id, Is.EqualTo(expectedUser.Id));
        Assert.That(users.GetValue(2).Name, Is.EqualTo(expectedUser.Name));
        Assert.That(users.GetValue(2).Email, Is.EqualTo(expectedUser.Email));
        Assert.That(users.GetValue(2).Password, Is.EqualTo(expectedUser.Password));
    }
    
    [Test]
    public void PrependTest() // ???
    {
        
    }
    
    [Test]
    public void AppendTest()
    {
        User expectedUser = new User(1, "Test User 1", "test.user1@gmail.com", "testuser1");
        
        users.AddFirst(expectedUser);
        
        Assert.That(users.GetValue(0).Id, Is.EqualTo(expectedUser.Id));
        Assert.That(users.GetValue(0).Name, Is.EqualTo(expectedUser.Name));
        Assert.That(users.GetValue(0).Email, Is.EqualTo(expectedUser.Email));
        Assert.That(users.GetValue(0).Password, Is.EqualTo(expectedUser.Password));
    }
    
    [Test]
    public void InsertTest()
    {
        User expectedUser = new User(3, "Test User 3", "test.user3@gmail.com", "testuser3");
        
        users.Insert(expectedUser, 2);
        
        Assert.That(users.GetValue(2).Id, Is.EqualTo(expectedUser.Id));
        Assert.That(users.GetValue(2).Name, Is.EqualTo(expectedUser.Name));
        Assert.That(users.GetValue(2).Email, Is.EqualTo(expectedUser.Email));
        Assert.That(users.GetValue(2).Password, Is.EqualTo(expectedUser.Password));
    }
    
    [Test]
    public void ReplaceTest()
    {
        User expectedUser = new User(3, "Test User 3", "test.user3@gmail.com", "testuser3");
        
        users.Replace(expectedUser, 2);
        
        Assert.That(users.GetValue(2).Id, Is.EqualTo(expectedUser.Id));
        Assert.That(users.GetValue(2).Name, Is.EqualTo(expectedUser.Name));
        Assert.That(users.GetValue(2).Email, Is.EqualTo(expectedUser.Email));
        Assert.That(users.GetValue(2).Password, Is.EqualTo(expectedUser.Password));
    }
    
    [Test]
    public void DeleteFirstTest()
    {
        User expectedUser = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
        
        users.RemoveFirst();
        
        // first item should be what index 1 was before
        Assert.That(users.GetValue(0).Id, Is.EqualTo(expectedUser.Id));
        Assert.That(users.GetValue(0).Name, Is.EqualTo(expectedUser.Name));
        Assert.That(users.GetValue(0).Email, Is.EqualTo(expectedUser.Email));
        Assert.That(users.GetValue(0).Password, Is.EqualTo(expectedUser.Password));
    }
    
    [Test]
    public void DeleteLastTest()
    {
        User expectedUser = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
        
        users.RemoveLast();
        
        // last item should be what index 2 was before
        Assert.That(users.GetValue(2).Id, Is.EqualTo(expectedUser.Id));
        Assert.That(users.GetValue(2).Name, Is.EqualTo(expectedUser.Name));
        Assert.That(users.GetValue(2).Email, Is.EqualTo(expectedUser.Email));
        Assert.That(users.GetValue(2).Password, Is.EqualTo(expectedUser.Password));
    }
    
    [Test]
    public void DeleteMiddleTest()
    {
        User expectedUser = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
        
        users.Remove(2); // roughly middle
        
        // index 2 should now be what index 3 was
        Assert.That(users.GetValue(2).Id, Is.EqualTo(expectedUser.Id));
        Assert.That(users.GetValue(2).Name, Is.EqualTo(expectedUser.Name));
        Assert.That(users.GetValue(2).Email, Is.EqualTo(expectedUser.Email));
        Assert.That(users.GetValue(2).Password, Is.EqualTo(expectedUser.Password));
    }

    [Test]
    public void EmptyListTest()
    {
        users.Clear();
        
        // head should be null
        Assert.That(users.IsEmpty(), Is.True);
    }
}