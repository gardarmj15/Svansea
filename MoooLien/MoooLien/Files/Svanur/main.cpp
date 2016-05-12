#include <iostream>

using namespace std;

int sum(int a, int b)
{
    int sum = a + b;
    return sum;
}

int main()
{
    int sumof = sum(2, 7);

    cout << sumof;
    return 0;
}
