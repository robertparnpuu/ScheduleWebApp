namespace Core 
{
    public static class ErrorMessages {
        public static string ConcurrencyOnDelete =>
            "The record you attempted to delete "
            + "was modified by another user after you selected delete. "
            + "The delete operation was canceled and the current values in the "
            + "database have been displayed. If you still want to delete this "
            + "record, click the Delete button again.";
        public static string ConcurrencyOnEdit =>
        "The record you attempted to edit "
              + "was modified by another user after you. The "
              + "edit operation was canceled and the current values in the database "
              + "have been displayed. If you still want to edit this record, click "
              + "the Save button again.";
        public static string PersonNotFree =>
            "Person is not free on this date";
    }
}
