Option Strict On
Public Class CarInventory

    Private Shared carCount As Integer                     ' shared provate variable to store nuber of cars in inventory
    Private carIndentificationNumber As Integer = 0        ' private variable to hold the cars Identification number
    Private carMake As String = String.Empty               ' private variable to hold the cars make
    Private carYear As Integer = 0                         ' private variable to hold the cars year
    Private carModel As String = String.Empty              ' private variable to hold the cars Model
    Private carPrice As Double = 0.0                       ' private variable to hold the cars Price/ cost
    Private carIsNew As Boolean = False                    ' private variable to hold a true/ false condition which refers to if the car is new or used (true == new)


    ''' <summary>
    ''' Constructor - Default - creates a new car object
    ''' </summary>
    Private Sub AddCar()
        carCount += 1 'increases variable by 1 of the existing value (used for out customer ID number.)
        carIndentificationNumber = carCount 'assigns the car id
    End Sub

    ''' <summary>
    ''' Constructor - Parameterized - created a new car object
    ''' </summary>
    ''' <param name="make"></param>
    ''' <param name="model"></param>
    ''' <param name="year"></param>
    ''' <param name="price"></param>
    ''' <param name="isNew"></param>
    Public Sub New(make As String, model As String, year As Integer, price As Double, isNew As Boolean)

        ' call the other constructor 
        ' to set the car count
        ' to set the car id
        Me.AddCar()

        carMake = make    'sets the car make
        carModel = model  'sets the car model
        carYear = year    'sets the car year
        carPrice = price  'sets the car price
        carIsNew = isNew  'sets the cars condition status
    End Sub

    ''' <summary>
    ''' Count ReadOnly Property - Gets the number of cars created/instantiated
    ''' </summary>
    ''' <returns>Integer</returns>
    Public ReadOnly Property Count() As Integer
        Get
            Return carCount
        End Get
    End Property

    ''' <summary>
    ''' IndentificationNumber ReadOnly Property - Gets the SPECIFIC ID number of a car.
    ''' </summary>
    ''' <returns>Integer</returns>
    Public ReadOnly Property IdentificationNumber() As Integer
        Get
            Return carIndentificationNumber
        End Get
    End Property

    ''' <summary>
    ''' CarConditionStatus Property - Gets AND Sets the car condition status (new / used --> true / false)
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Property CarConditionStatus() As Boolean
        Get
            Return carIsNew
        End Get
        Set(ByVal value As Boolean)
            carIsNew = value
        End Set
    End Property

    ''' <summary>
    ''' Make - Gets and Sets the make of a car
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Make() As String
        Get
            Return carMake
        End Get
        Set(ByVal value As String)
            carMake = value
        End Set
    End Property

    ''' <summary>
    ''' Model property - Gets and Sets the model of a car
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Model() As String
        Get
            Return carModel
        End Get
        Set(ByVal value As String)
            carModel = value
        End Set
    End Property

    ''' <summary>
    ''' Year property - Gets and Sets the year of the car
    ''' </summary>
    ''' <returns>Integer</returns>
    Public Property Year() As Integer
        Get
            Return carYear
        End Get
        Set(ByVal value As Integer)
            carYear = value
        End Set
    End Property

    ''' <summary>
    ''' Price property - Gets and Sets the price of the car
    ''' </summary>
    ''' <returns>Double</returns>
    Public Property Price() As Double
        Get
            Return carPrice
        End Get
        Set(ByVal value As Double)
            carPrice = value
        End Set
    End Property

    Public Function GetData() As String
        Return "Car: " & carMake & " " & carModel & " " & carYear & ". It is valued at " & carPrice & ". Condition: " & IIf(carIsNew = True, "New", "Used").ToString()
    End Function

End Class
