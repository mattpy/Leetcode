namespace Leetcode.Graphs;

class CourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        int[] dependencyCount = new int[numCourses];
        Dictionary<int, List<int>> reverseMap = new(numCourses);

        foreach (int[] prereq in prerequisites)
        {
            int course = prereq[0];
            int dependency = prereq[1];

            if (!reverseMap.ContainsKey(dependency))
                reverseMap[dependency] = new List<int>();

            reverseMap[dependency].Add(course);
            dependencyCount[course]++;
        }

        Queue<int> queue = new();
        for (int i = 0; i < dependencyCount.Length; i++)
        {
            if (dependencyCount[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        int coursesTaken = 0;
        while (queue.Count > 0)
        {
            int courseTaken = queue.Dequeue();
            coursesTaken++;

            if (!reverseMap.ContainsKey(courseTaken)) continue;

            foreach (var neighbor in reverseMap[courseTaken])
            {
                dependencyCount[neighbor]--;
                if (dependencyCount[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return coursesTaken == numCourses;
    }
}
