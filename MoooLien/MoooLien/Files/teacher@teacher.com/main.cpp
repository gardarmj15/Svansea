#include <iostream>

using namespace std;

int sum(int a, int b)
{
    int sum = a + b;
    return sum;
}

int main()
{
    int a, b;
    cin >> a;
    cin >> b;

    int sumof = sum(a, b);

    cout << sumof;
    return 0;
}
