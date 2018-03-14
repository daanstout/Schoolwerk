import ('ResourceGatherer.Entities.MovingEntities')
import ('System')

function print(text)
	Console:WriteLine(text)
end

function incr(entity)
	entity.counter = entity.counter + 1
end