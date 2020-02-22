import static org.junit.Assert.assertTrue;
import static org.junit.jupiter.api.Assertions.*;

import java.util.ArrayList;

import org.junit.Before;
import org.junit.jupiter.api.Test;

public class TestingArrayList {

	ArrayList<String> myTest = new ArrayList<>(); //creates to initial capacity of 10.
	
	@Test
	public void testAdd() {
		myTest.add("Red");  // the regular add(E e) 
		myTest.add("Green");
		System.err.println("--Running testAdd()--");
		System.out.println(myTest);	
		
		myTest.add(1, "Blue"); //the add at index:(int. index, E element).
		System.out.println("--Adding \"Blue\" at index 1, Array should have 3 objects now:-- \n" + myTest);	
		
		assertEquals(2, myTest.size() -1);  // new size is 3
		assertEquals("Green", myTest.get(2)); //Green should be at index 2 now.    
		System.err.println("------ testAdd() passing ------- \n\n");
	} 
	
	@Test
	public void testContains() {
		myTest.add("a");
		myTest.add("B");
		myTest.add("c");
		System.err.println("--Running testContains()--");
		System.out.println(myTest);
		assertTrue(myTest.contains("B"));
		System.out.println("--Returns true if letter \"B\" exist--\n" + myTest.contains("B"));
		System.out.println("--Should return false, letter \"b\" not in array--\n" + myTest.contains("b"));
		assertFalse(myTest.contains("b"));
		System.err.println("------ testContains() passing ------- \n\n");

	}

	@Test
	public void testRemove() {
		myTest.add("Bob");
		myTest.add("Charly");
		myTest.add("Pete");
		myTest.add("Fred");
		System.err.println("--Running testRemove()--");
		System.out.println(myTest);	
		assertEquals(4, myTest.size()); //size should be 4
		myTest.remove(2); //removing object using index
		myTest.remove("Fred");
		//assertTrue(myTest.size() == 2); //should have only 2 elements
		System.out.println("--Removing \"Pete and Fred\", myTest should only have \"Bob and Chaly\"--\n" + myTest);
		System.err.println("------ testRemove() passing ------\n\n");

	}	
	@Test
	public void testGet() {
		myTest.add("Lion");
		myTest.add("Tiger");
		myTest.add("Zebra");
		System.err.println("--Running testGet()--");
		System.out.println(myTest);
		assertEquals("Tiger", myTest.get(1));
		System.out.println("--if passed, it should return Tiger:--\n" + myTest.get(1));
		System.err.println("----- testGet() passing -----\n\n");
	}
	
	@Test
	public void testSize() {
		myTest.add("Dog");
		myTest.add("Cat");
		myTest.add("Mouse");
		System.err.println("--Running testSize()--");
		System.out.println(myTest);		
		assertEquals(3, myTest.size());
		System.out.println("--myTest.size() should be 3:--");
		System.out.println(myTest.size());
		System.out.println("--removing all items, size() will be 0:--");
		myTest.removeAll(myTest);
		System.out.println(myTest.size());
		assertTrue(myTest.size() == 0);
		System.err.println("----- testSize() passing ------\n\n");
	}
	
	@Test
	public void testIndexOf() {
		myTest.add("x");
		myTest.add("y");
		myTest.add("z");
		System.err.println("--Running testIndexOf()--");
		System.out.println(myTest);
		assertEquals(2, myTest.indexOf("z"));
		System.out.println("--the index of \"z\" should be 2:--\n" + myTest.indexOf("z"));
		System.err.println("----- testIndexOf() passing ------\n\n");
	}

}
