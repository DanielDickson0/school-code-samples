package com.homework.customsort;
import java.security.SecureRandom;

// Based on Fig. 21.5: ListTest.java modified by Prof Terri Sipantzi of Liberty University
// ListTest class to demonstrate SortedList capabilities.


public class ListTest 
{
   public static void main(String[] args)
   {
      System.out.println("Daniel Dickson -- Lab #8\n");
      
      SortedList<Integer> list = new SortedList<>(); 
      SecureRandom rNum = new SecureRandom();

      // insert 25 random (between 0 and 99 inclusive) integers into the list
      for (int i = 0; i < 25; i++) 
		  //Your job is to modify insertSorted so that it creates a
		  //sorted list one element at a time.
          list.insertSorted(rNum.nextInt(100));

      list.print();
   }
} // end class ListTest


/**************************************************************************
 * (C) Copyright 1992-2014 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
