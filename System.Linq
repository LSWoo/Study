[ Sum ]
 집합 내 모든 원소 더하기 

아래와 같이 사용하여 words 배열의 string 원소의 길이를 알수있다.
string[] words = { "cherry", "apple", "blueberry" }; 
double totalChars = words.Sum(w => w.Length);
totalChars = 20 이다.
  
[ Count ]
  Distinct() 메서드를 사용하여 중복되는 값을 제외한 개수를 샙니다.
int[] factorsOf300 = { 2, 2, 3, 5, 5 };
int uniqueFactors = factorsOf300.Distinct().Count();
uniqueFactors = 3
  
[ Min ]
  최솟값 찾기
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
int minNum = numbers.Min();
 minNum = 0;

[ Max ]
  최댓값 찾기
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
int maxNum = numbers.Max();
maxNum = 9
  
[ Average ]
  평균 구하기
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
double averageNum = numbers.Average();
averageNum = 4.5
