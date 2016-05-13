/*
  Problem Solving 2015
  Problem Set - Week 11
  Solution to sample problem.
*/
#include <iostream>
#include <cassert>

#ifndef ONLINE_JUDGE
#include<cstdio>
#define read(file) freopen(file,"r",stdin)
#define write(file) freopen(file,"w",stdout)
#else
#define read(file)
#define write(file)
#endif

using namespace std;

const int SETMAX = 50;

// We define boolean arrays (or pointers) as the type Set.
typedef bool* Set;

/*
 * Creates a new empty set.
 */
Set new_set() {
    bool* s = new bool[SETMAX];
    for(int i = 0; i < SETMAX; i++) {
        s[i] = false;
    }
    return s;
}

/*
 * Writes s to stdout in standard set notation, i.e. a comma separated list of
 * the elements of s in increasing order, surrounded by curly brackets, e.g.
 * {1,4,23}.
 */
void set_output(const Set s) {
    bool first = true;
    cout << '{';
    for(int i = 0; i < SETMAX; i++) {
        if(s[i]) {
            if(!first) {
                cout << ',';
            }
            first = false;
            cout << i + 1 ;
        }
    }
    cout << '}' << endl;
}

/*
 * Reads in a set from standard input.

 * The form of the set is {1,2,21,32}, i.e. comma separated list of integers
 * surrounded by curly brackets.  White space can be included before and within
 * the brackets.  The set is stored in the Boolean array s, such that if the
 * set contains the integer n, then s[n-1] is true; otherwise s[n-1] is false.
 */
Set set_input() {
    Set s = new_set();

    char sep;
    assert(cin >> sep); // reads the opening bracket '{'

    // Check if the input is the empty set.
    assert(cin >> sep);
    if(sep == '}') {
        return s;
    } else {
        cin.putback(sep);
    }

    int element;
    while(sep != '}') {
        assert(cin >> element >> sep);
        if(1 <= element && element <= SETMAX) {
            s[element-1] = true;
        } else {
            cout << "Element value out of range: " << element << endl;
        }
    }
    return s;
}

/*
 *  Returns a new set containing the intersection
 *  of the sets s1 and s2.
 */
Set intersection(const Set s1, const Set s2) {
    Set res = new_set();
    for(int i = 0; i < SETMAX; i++) {
        res[i] = s1[i] | s2[i];
    }
    return res;
}


/*
 * The solution to the sample problem.
 *
 * (Create a new function like this for each problem, e.g., ex_1, ex_2, etc.)
 */
void ex_sample() {
    Set s1 = set_input();
    Set s2 = set_input();

    Set result = intersection(s1, s2);
    set_output(result);

    delete s1;
    delete s2;
    delete result;
}

int main() {
    // Uncomment the next line to read test data from a file
    //read("input.txt");
    // Uncomment the next line to write the output to a file
    //write("output.txt");

    int no_of_test;
    assert(cin >> no_of_test);
    for(int i = 0; i < no_of_test; i++) {
        ex_sample();
    }
    return 0;
}
