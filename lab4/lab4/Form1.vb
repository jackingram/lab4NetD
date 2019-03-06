Option Strict On
Public Class frmMain


    Private carList As New SortedList                                 'collection of cars on the list
    Private currentCarIdentificationNumber As String = String.Empty   ' current selected car (id based)
    Private editMode As Boolean = False


    ''' <summary>
    ''' btnEnter_Click - Will validate that the data entered into the controls is appropriate.
    '''                - Once the data is validated a car object will be create using the  
    '''                - parameterized constructor. It will also insert the new car object
    '''                - into the carList collection. It will also check to see if the data in
    '''                - the controls has been selected from the listview by the user. In that case
    '''                - it will need to update the data in the specific car object and the 
    '''                - listview as well.
    ''' </summary>
    ''' <param name="sender">Object</param>
    ''' <param name="e">EventArgs</param>
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        Dim car As CarInventory        ' declare a Car class
        Dim carItem As ListViewItem    ' declare a ListViewItem class

        ' validate the data in the form
        If IsValidInput() = True Then

            ' set the edit flag to true
            editMode = True

            ' 
            lbResult.Text = "It worked!"

            ' if the current customer identification number has a no value
            ' then this is not an existing item from the listview
            If currentCarIdentificationNumber.Trim.Length = 0 Then

                ' create a new customer object using the parameterized constructor
                car = New CarInventory(cmbMake.Text, txtModel.Text, Convert.ToInt32(cmbYear.Text), Convert.ToDouble(txtPrice.Text), chkNew.Checked)

                ' add the customer to the customerList collection
                ' using the identoification number as the key
                ' which will make the customer object easier to
                ' find in the customerList collection later
                carList.Add(car.IdentificationNumber.ToString(), car)

            Else
                ' if the current customer identification number has a value
                ' then the user has selected something from the list view
                ' so the data in the customer object in the customerList collection
                ' must be updated

                ' so get the customer from the custmers collection
                ' using the selected key
                car = CType(carList.Item(currentCarIdentificationNumber), CarInventory)

                ' update the data in the specific object
                ' from the controls
                car.Make = cmbMake.Text
                car.Model = txtModel.Text
                car.Price = txtPrice.Text
                car.CarConditionStatus = chkNew.Checked
            End If

            ' clear the items from the listview control
            lvwCustomers.Items.Clear()

            ' loop through the customerList collection
            ' and populate the list view
            For Each customerEntry As DictionaryEntry In customerList

                ' instantiate a new ListViewItem
                customerItem = New ListViewItem()

                ' get the customer from the list
                customer = CType(customerEntry.Value, Customer)

                ' assign the values to the ckecked control
                ' and the subitems
                customerItem.Checked = customer.VeryImportantPersonStatus
                customerItem.SubItems.Add(customer.IdentificationNumber.ToString())
                customerItem.SubItems.Add(customer.Title)
                customerItem.SubItems.Add(customer.FirstName)
                customerItem.SubItems.Add(customer.LastName)

                ' add the new instantiated and populated ListViewItem
                ' to the listview control
                lvwCustomers.Items.Add(customerItem)

            Next customerEntry

            ' Alternate looping strategy
            'For index As Integer = 0 To customerList.Count - 1

            '    ' instantiate a new ListViewItem
            '    customerItem = New ListViewItem()

            '    ' get the customer from the list
            '    customer = CType(customerList(customerList.GetKey(index)), Customer)

            '    ' assign the values to the ckecked control
            '    ' and the subitems
            '    customerItem.Checked = customer.VeryImportantPersonStatus
            '    customerItem.SubItems.Add(customer.IdentificationNumber.ToString())
            '    customerItem.SubItems.Add(customer.Title)
            '    customerItem.SubItems.Add(customer.FirstName)
            '    customerItem.SubItems.Add(customer.LastName)

            '    ' add the new instantiated and populated ListViewItem
            '    ' to the listview control
            '    lvwCustomers.Items.Add(customerItem)

            'Next index

            ' clear the controls
            Reset()

            ' set the edit flag to false
            editMode = False

        End If

    End Sub






    ''' <summary>
    ''' Exits the program
    ''' </summary>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Function IsValidInput() As Boolean

        Dim returnValue As Boolean = True
        Dim outputMessage As String = String.Empty

        ' check if the title has been selected
        If cmbMake.SelectedIndex = -1 Then

            ' If not set the error message
            outputMessage += "Please select the car's Make. " & vbCrLf

            ' And, set the return value to false
            returnValue = False

        End If

        ' check if the title has been selected
        If cmbYear.SelectedIndex = -1 Then

            ' If not set the error message
            outputMessage += "Please select the car's Year. " & vbCrLf

            ' And, set the return value to false
            returnValue = False

        End If

        ' check if the first name has been entered
        If txtModel.Text.Trim.Length = 0 Then

            ' If not set the error message
            outputMessage += "Please enter the car's Model. " & vbCrLf

            ' And, set the return value to false
            returnValue = False

        End If

        ' check if the first name has been entered
        If txtPrice.Text.Trim.Length = 0 Then

            ' If not set the error message
            outputMessage += "Please enter the car's Price. " & vbCrLf

            ' And, set the return value to false
            returnValue = False

        End If

        ' check to see if any value
        ' did not validate
        If returnValue = False Then

            ' show the message(s) to the user
            lbResult.Text = "ERRORS! " & vbCrLf & outputMessage

        End If

        ' return the boolean value
        ' true if it passed validation
        ' false if it did not pass validation
        Return returnValue

    End Function

End Class
