public class Solution 
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode dummyHead = new ListNode(0);
        ListNode current = dummyHead;
        int carry = 0;
    
        // While there is a value to consider (either ListNode is not null or there is a carry value)
        while (l1 != null || l2 != null || carry != 0)
        {
            // If a ListNode is null but we still have values to consider, add a value of 0. This 'carries' the 10, moving the results node along.
            l1 ??= new ListNode(0);
            l2 ??= new ListNode(0);
                
            // Calculate the value to add to the results node.
            int value1 = l1.val > 0 ? l1.val : 0;
            int value2 = l2.val > 0 ? l2.val : 0;
            int total = value1 + value2 + carry;
            
            carry = total / 10;

            // The modulus of the total will give us the value to carry over to the next iteration.
            current.next = new ListNode(total % 10);
            
            // Move the iterating node on.
            current = current.next;

            // The break clause: If the next node is null then set the current value to null (we've already retrieved the result).
            if (l1.next != null)
                l1 = l1.next;
            else l1 = null;

            if (l2.next != null)
                l2 = l2.next;
            else l2 = null;
        }

        // The iterating node held all of the results in reverse, so just return the 'next' value (the last value added, which holds all of the calculations).
        return dummyHead.next;
    }
}

public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) 
    {
        this.val = val;
        this.next = next;
    }
}